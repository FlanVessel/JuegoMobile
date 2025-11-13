using UnityEngine;
using System.Numerics;
using UnityEngine.UI;
using TMPro;

public class UI_PrincipalMenu : UI_Window
{
    [Header("Botones superiores")]
    [SerializeField] private Button _buttonProfile;
    [SerializeField] private Button _buttonNotes;
    [SerializeField] private Button _buttonSettings;

    [Header("Boton Central y Contador")]
    [SerializeField] private Button _buttonGato;
    [SerializeField] private TMP_Text _textCounterGato;

    [Header("Botones inferiores")]
    [SerializeField] private Button _buttonShop;
    [SerializeField] private Button _buttonFarm;

    private BigInteger count = BigInteger.Zero;

    void Awake()
    {
        ConectarBotones();
        count = SaveService.Points;
        ActualizarEtiqueta();
    }

    private void ConectarBotones()
    {
        //Cada boton nos llevara a su respectiva ventana
        //Los superiores nos llevan a Profile, Notes y Settings
        if (_buttonProfile) _buttonProfile.onClick.AddListener(() => VerPrincipal(WindowsIDs.UI_Profile));
        if (_buttonNotes) _buttonNotes.onClick.AddListener(() => VerPrincipal(WindowsIDs.UI_Notes));
        if (_buttonSettings) _buttonSettings.onClick.AddListener(() => VerPrincipal(WindowsIDs.UI_Settings));

        //Los inferiores nos llevan a Tienda y Granjas
        if (_buttonShop) _buttonShop.onClick.AddListener(() => CambiarVentana(WindowsIDs.UI_Tienda));
        if (_buttonFarm) _buttonFarm.onClick.AddListener(() => CambiarVentana(WindowsIDs.UI_Granjas));

        //El Central es el contador de clicks que da el jugador
        if (_buttonGato) _buttonGato.onClick.AddListener(Incrementar);
    }

    private void CambiarVentana(string windowID)
    {
        UI_Manager.Instance.HideUI(WindowID);
        UI_Manager.Instance.ShowUI(windowID);
    }

    private void VerPrincipal(string windowID)
    {
        UI_Manager.Instance.ShowUI(windowID);
    }

    private void Incrementar()
    {
        count += BigInteger.One;
        SaveService.Points = count;
        SaveService.Save();
        ActualizarEtiqueta();
    }

    private void ActualizarEtiqueta()
    {
        if (!_textCounterGato) return;

        _textCounterGato.text = FormatearBig(count);
    }

    private string FormatearBig(BigInteger value)
    {
        if (value < 1000) return value.ToString();

        string[] suffixes = { "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc" };
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
