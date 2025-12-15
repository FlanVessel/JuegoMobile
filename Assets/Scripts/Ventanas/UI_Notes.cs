using UnityEngine;
using UnityEngine.UI;

public class UI_Notes : UI_Window
{
    [Header("Boton Cerrar")]
    [SerializeField] private Button _buttonBack;

    void Awake()
    {
        Regresemos();
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
}
