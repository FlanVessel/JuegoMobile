using UnityEngine;
using System.Numerics;
using UnityEngine.UI;
using TMPro;
using System.Collections; 

public class UI_PrincipalMenu : UI_Window
{
    [Header("Botones superiores")]
    [SerializeField] private Button _buttonProfile;
    [SerializeField] private Button _buttonNotes;
    [SerializeField] private Button _buttonSettings;

    [Header("Boton Central y Contador")]
    [SerializeField] private Button _buttonGato;
    [SerializeField] private TMP_Text _textCounterGato;
    [SerializeField] private GameObject _imagenActivar;
    [SerializeField] private GameObject _imagenActivar2;
    [SerializeField] private GameObject _imagenActivar3;
    [SerializeField] private GameObject _imagenActivar4;
    [SerializeField] private GameObject _imagenActivar5;
    [SerializeField] private GameObject _imagenActivar6;

    [Header("Botones inferiores")]
    [SerializeField] private Button _buttonShop;
    [SerializeField] private Button _buttonFarm;

    private BigInteger count = BigInteger.Zero;  //Empezamos con el contador en 0. Ya que le estamos diciendo a count que es igual a 0.

    void Awake()
    {
        ConectarBotones();
        count = SaveService.Points;
        ActualizarEtiqueta();
    }

    private void Update()
    {
        if (SaveService.Points != count)
        {
            RefrescarPuntosExternos();
        }
    }

    private void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            RevisarCompra();
        }
        else
        {
            StartCoroutine(EsperarGameManager());
        }
    }

    private IEnumerator EsperarGameManager()
    {
        yield return null;

        if (GameManager.Instance != null)
        {
            RevisarCompra();
        }
        else
        {
            Debug.LogError("GameManager es NULL, Revisa crack!!!");
        }
    }
    
    private void RevisarCompra()
    {
        Debug.Log("Comprobando referencias UI_PrincipalMenu...");

        Debug.Log("_imagenActivar = " + (_imagenActivar == null ? "NULL" : "OK"));
        Debug.Log("_imagenActivar2 = " + (_imagenActivar2 == null ? "NULL" : "OK"));
        Debug.Log("GameManager.Instance = " + (GameManager.Instance == null ? "NULL" : "OK"));

        if (GameManager.Instance == null)
        {
            Debug.LogWarning("RevisarCompra() llamando antes de que exista GameManager");
        }

        _imagenActivar?.SetActive(GameManager.Instance.PrimerItemComprado);
        _imagenActivar2?.SetActive(GameManager.Instance.item2Comprado);
        _imagenActivar3?.SetActive(GameManager.Instance.item3Comprado);
        _imagenActivar4?.SetActive(GameManager.Instance.item4Comprado);
        _imagenActivar5?.SetActive(GameManager.Instance.item5Comprado);
        _imagenActivar6?.SetActive(GameManager.Instance.item6Comprado);
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
        count += BigInteger.One;  //Sumamos uno

        SaveService.Points = count;  
        SaveService.Save();  //lo actualizmaos en el JSON

        ActualizarEtiqueta();  //Actualizamos el texto
    }

    private void ActualizarEtiqueta()
    {
        if (!_textCounterGato) return;

        _textCounterGato.text = FormatearBig(count);
    }

    private string FormatearBig(BigInteger value)
    {
        if (value < 1000) return value.ToString();

        string[] suffixes = { "", "K", "M", "B", "T", "Qa", "Qi" };
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

    public void RefrescarPuntosExternos()
    {
        count = SaveService.Points;
        ActualizarEtiqueta();
    }

    public override void Show(bool instant = false)
    {
        base.Show(instant);
        RevisarCompra();
        RefrescarPuntosExternos();
    }
}
