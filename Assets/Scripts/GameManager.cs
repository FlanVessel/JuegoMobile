using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Estado de Compras de Tienda")]
    public bool PrimerItemComprado;

    public bool item2Comprado;

    public bool item3Comprado;

    public bool item4Comprado;

    public bool item5Comprado;

    public bool item6Comprado;

    [Header("Estado de Compras de Granja")]
    public int granjaNivel = 0;   // 0 = no comprada, 1-10 = niveles
    public int granjaProduccion = 0; // Puntos por segundo actuales
    private float timerGranja = 0f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        PrimerItemComprado = SaveService.AutoClickBought;
        item2Comprado = SaveService.Tienda2Bought;
        item3Comprado = SaveService.Tienda3Bought;
        item4Comprado = SaveService.Tienda4Bought;
        item5Comprado = SaveService.Tienda5Bought;
        item6Comprado = SaveService.Tienda6Bought;

        granjaNivel = SaveService.GranjaNivel;
        granjaProduccion = granjaNivel;
    }

    public void MarcarPrimerItemComprado()
    {
        PrimerItemComprado = true;
        SaveService.AutoClickBought = true;
        SaveService.Save();
    }  

    public void MarcarItem2Comprado()
    {
        item2Comprado = true;
        SaveService.Tienda2Bought = true;
        SaveService.Save();
    }

    public void MarcarItem3Comprado()
    {
        item3Comprado = true;
        SaveService.Tienda3Bought = true;
        SaveService.Save();
    }

    public void MarcarItem4Comprado()
    {
        item4Comprado = true;
        SaveService.Tienda4Bought = true;
        SaveService.Save();
    }

    public void MarcarItem5Comprado()
    {
        item5Comprado = true;
        SaveService.Tienda5Bought = true;
        SaveService.Save();
    }

    public void MarcarItem6Comprado()
    {
        item6Comprado = true;
        SaveService.Tienda6Bought = true;
        SaveService.Save();
    }

    private void Update()
    {
        if (granjaProduccion > 0)
        {
            timerGranja += Time.deltaTime;

            if (timerGranja >= 1f)
            {
                timerGranja = 0f;
                SaveService.Points += granjaProduccion;
                SaveService.Save();
            }
        }
    }

    public void ComprarGranja()
{
    granjaNivel = 1;
    granjaProduccion = 1; // nivel 1 = 1 punto por segundo

    SaveService.GranjaNivel = granjaNivel;
    SaveService.Save();
}

public void MejorarGranja()
{
    if (granjaNivel >= 10)
        return;

    granjaNivel++;
    granjaProduccion = granjaNivel; // puedes cambiar fórmula

    SaveService.GranjaNivel = granjaNivel;
    SaveService.Save();
}

public bool GranjaComprada()
{
    return granjaNivel > 0;
}
}
