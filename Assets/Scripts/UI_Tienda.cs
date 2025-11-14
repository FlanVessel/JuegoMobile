using UnityEngine;
using UnityEngine.UI;

public class UI_Tienda : UI_Window
{
    [Header("ScrollView / Content")]
    [SerializeField] private Button _itemButton1;
    [SerializeField] private Button _itemButton2;
    [SerializeField] private Button _itemButton3;
    [SerializeField] private Button _itemButton4;
    [SerializeField] private Button _itemButton5;
    [SerializeField] private Button _itemButton6;

    [Header("Botones inferiores")]
    [SerializeField] private Button _buttonMenu;

    void Awake()
    {
        ConectarContenido();
        ConectarBotones();
    }

    private void ConectarContenido()
    {
        if (_itemButton1) _itemButton1.onClick.AddListener(() => AbrirElegir(WindowsIDs.UI_ElegirTienda));
        if (_itemButton2) _itemButton2.onClick.AddListener(() => AbrirElegir(WindowsIDs.UI_ElegirTienda2));
        if (_itemButton3) _itemButton3.onClick.AddListener(() => AbrirElegir(WindowsIDs.UI_ElegirTienda3));
        if (_itemButton4) _itemButton4.onClick.AddListener(() => AbrirElegir(WindowsIDs.UI_ElegirTienda4));
        if (_itemButton5) _itemButton5.onClick.AddListener(() => AbrirElegir(WindowsIDs.UI_ElegirTienda5));
        if (_itemButton6) _itemButton6.onClick.AddListener(() => AbrirElegir(WindowsIDs.UI_ElegirTienda6));
    }

    private void AbrirElegir(string windowID)
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
