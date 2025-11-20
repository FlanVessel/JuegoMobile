using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UI_Granjas : UI_Window
{
    [Header("ScrollView / Content")]

    [Header("Primer Boton y Texto")]
    [SerializeField] private Button _buttonGranja1;
    [SerializeField] private TMP_Text _textGranja1;
    [SerializeField] private int costoBase = 100;

    [Header("Botones inferiores")]
    [SerializeField] private Button _buttonMenu;

    void Update()
    {
        RefrescarUI();
    }

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

    public void RefrescarUI()
    {
        if (_textGranja1 == null)
            return;

        if (GameManager.Instance == null)
        {
            _textGranja1.text = $"Costo: {costoBase}";
            return;
        }

        int nivel = GameManager.Instance.granjaNivel;

        if (nivel == 0)
        {
            _textGranja1.text = $"Costo: {costoBase}";
        }
        else
        {
            int costoMejora = costoBase * (nivel + 1);
            _textGranja1.text = $"Nivel {nivel} – Mejora: {costoMejora}";
        }
    }
}
