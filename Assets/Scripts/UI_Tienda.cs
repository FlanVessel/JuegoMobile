using UnityEngine;
using UnityEngine.UI;

public class UI_Tienda : UI_Window
{
    [Header("ScrollView / Content")]
    [SerializeField] private Transform _contentRoot;

    [Header("Botones inferiores")]
    [SerializeField] private Button _buttonMenu;

    void Awake()
    {
        ConectarContenido();
        ConectarBotones();
    }

    private void ConectarContenido()
    {
        if (!_contentRoot) return;

        var buttons = _contentRoot.GetComponentsInChildren<Button>(true);
        foreach (var b in buttons)
        {
            b.onClick.AddListener(AbrirElegirTienda);
        }
    }

    private void AbrirElegirTienda()
    {
        UI_Manager.Instance.ShowUI(WindowsIDs.UI_ElegirTienda);
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
