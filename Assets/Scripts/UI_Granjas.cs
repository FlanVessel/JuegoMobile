using UnityEngine;
using UnityEngine.UI;
public class UI_Granjas : UI_Window
{
    [Header("ScrollView / Content")]
    [SerializeField] private Button _buttonGranja1;

    [Header("Botones inferiores")]
    [SerializeField] private Button _buttonMenu;

    void Awake()
    {
        ConectarContenido();
        ConectarBotones();
    }

    private void ConectarContenido()
    {
        if (_buttonGranja1) _buttonGranja1.onClick.AddListener(() => AbrirElegirGranja(WindowsIDs.UI_ElegirGranja));
    }

    private void AbrirElegirGranja(string windowID)
    {
        UI_Manager.Instance.ShowUI(windowID);
    }

    private void ConectarBotones()
    {
        if (_buttonMenu) _buttonMenu.onClick.AddListener(() => CambiarVentana(WindowsIDs.UI_Principal));
    }
    
    private void CambiarVentana(string windowID)
    {
        UI_Manager.Instance.HideUI(WindowID);
        UI_Manager.Instance.ShowUI(windowID);
    }
}
