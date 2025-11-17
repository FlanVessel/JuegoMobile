using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool PrimerItemComprado;

    public bool item2Comprado;

    public bool item3Comprado;

    public bool item4Comprado;

    private void Awake()
    {
        if (Instance == null) Instance = this;

        // Cargar desde el JSON al iniciar la escena
        PrimerItemComprado = SaveService.AutoClickBought;
        item2Comprado = SaveService.Tienda2Bought;
        item3Comprado = SaveService.Tienda3Bought;
        item4Comprado = SaveService.Tienda4Bought;
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
}
