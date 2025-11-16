using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
using TMPro;

public class UI_ElegirTienda2 : UI_Window
{
    [Header("Boton Cerrar")]
    [SerializeField] private Button _buttonBack;

    [Header("Boton Comprar")]
    [SerializeField] private TMP_Text _textPrecio;
    [SerializeField] private Button _buttonBuy;
    [SerializeField] private long baseCost = 500;

    void Awake()
    {
        if (_buttonBack)
            _buttonBack.onClick.AddListener(CerrarVentana);

        if (_buttonBuy)
            _buttonBuy.onClick.AddListener(Comprar);
    }

    void OnEnable()
    {
        // Cada vez que se abre esta ventana, refrescamos la UI
        RefrescarUI();
    }

    private void CerrarVentana()
    {
        UI_Manager.Instance.HideUI(WindowID);
    }

    private void RefrescarUI()
    {
        BigInteger cost = new BigInteger(baseCost);

        // Mostrar precio si tienes texto asignado
        if (_textPrecio)
            _textPrecio.text = FormatearBig(cost);

        if (SaveService.Tienda2Bought) //modificamos
        {
            _buttonBuy.interactable = false;
            _textPrecio.text = "Comprado";
        }

    }

    private void Comprar()
    {
        BigInteger cost = new BigInteger(baseCost);

        // Si ya está comprada, no hacemos nada
        if (SaveService.Tienda2Bought)
            return;

        // Intentar gastar puntos
        if (!SaveService.TrySpend(cost))
            return;

        SaveService.Tienda2Bought = true;
        
        GameManager.Instance.MarcarItem2Comprado();

        // Actualizar UI (desactiva botón, cambia texto, etc.)
        RefrescarUI();

        if (UI_Manager.Instance.GetUIWindow(WindowsIDs.UI_Principal) is UI_PrincipalMenu menu)
        {
            menu.RefrescarPuntosExternos();
        }
    }

    private string FormatearBig(BigInteger value)
    {
        if (value < 1000) return value.ToString();

        string[] suffixes = { "", "K", "M", "B", "T" };
        int tier = 0;
        BigInteger temp = value;

        while (temp >= 1000 && tier < suffixes.Length - 1)
        {
            temp /= 1000;
            tier++;
        }

        double shortVal = (double)value / System.Math.Pow(1000, tier);
        return $"{shortVal:0.##}{suffixes[tier]}";
    }
}
