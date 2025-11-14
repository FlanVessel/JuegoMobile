using UnityEngine;
using UnityEngine.UI;

public class UI_ElegirTienda : UI_Window
{
    [Header("Boton Cerrar")]
    [SerializeField] private Button _buttonBack;

    [Header("Boton Comprar")]
    [SerializeField] private Button _buttonBuy;

    void Awake()
    {
        Regresemos();
        Compremos();
    }

    private void Regresemos()
    {
        if (_buttonBack)
        {
            _buttonBack.onClick.AddListener(CerrarVentana);
        }
    }

    private void CerrarVentana()
    {
        UI_Manager.Instance.HideUI(WindowID);
    }

    private void Compremos()
    {
        if (_buttonBuy)
        {
            _buttonBuy.onClick.AddListener(Restemos);
        }
    }
    
    private void Restemos()
    {
        
    }
}
