using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_ElegirGranja : UI_Window
{
    [Header("Boton Cerrar")]
    [SerializeField] private Button _buttonBack;

    [Header("Boton comprar")]
    [SerializeField] private Button _buttonComprar;
    [SerializeField] private TMP_Text _textCosto;

    [Header("Boton Mejorar")]
    [SerializeField] private Button _buttonMejorar;
    [SerializeField] private TMP_Text _textNivel;

    [Header("Texto de Produccion")]
    [SerializeField] private TMP_Text _textProduccion;

    [SerializeField] private int costoBase = 100;

    void Awake()
    {
        Regresemos();

        if (_buttonComprar)
            _buttonComprar.onClick.AddListener(ComprarGranja);

        if (_buttonMejorar)
            _buttonMejorar.onClick.AddListener(MejorarGranja);
    }

    private void OnEnable()
    {
        StartCoroutine(EsperarGameManager());
    }

    private IEnumerator EsperarGameManager()
    {
        // Espera hasta que el Singleton exista
        yield return new WaitUntil(() => GameManager.Instance != null);

        ActualizarUI();
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

    private void ComprarGranja()
    {
        if (GameManager.Instance.GranjaComprada())
            return;

        if (SaveService.Points < costoBase)
            return;

        SaveService.Points -= costoBase;
        GameManager.Instance.ComprarGranja();

        SaveService.Save();
        ActualizarUI();
    }

    private void MejorarGranja()
    {
        if (!GameManager.Instance.GranjaComprada())
            return;

        int nivelActual = GameManager.Instance.granjaNivel;
        if (nivelActual >= 10)
            return;

        int costoMejora = costoBase * (nivelActual + 1);

        if (SaveService.Points < costoMejora)
            return;

        SaveService.Points -= costoMejora;
        GameManager.Instance.MejorarGranja();

        SaveService.Save();
        ActualizarUI();
    }

    private void ActualizarUI()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogWarning("GameManager es null en ActualizarUI");
            return;
        }

        int nivel = GameManager.Instance.granjaNivel;

        if (nivel == 0)
        {
            _textCosto.text = "Costo: 100 puntos";
            _textNivel.text = "Nivel: No comprado";
            _textProduccion.text = "Producción: 0 / seg";

            _buttonComprar.gameObject.SetActive(true);
            _buttonMejorar.gameObject.SetActive(false);
        }
        else
        {
            int costoMejora = costoBase * (nivel + 1);
            int produccion = nivel; // 1, 2, 3...  

            _textCosto.text = "Costo mejora: " + costoMejora;
            _textNivel.text = "Nivel: " + nivel;
            _textProduccion.text = "Producción: " + produccion + " / seg";

            _buttonComprar.gameObject.SetActive(false);
            _buttonMejorar.gameObject.SetActive(true);
        }
    }

}
