using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool PrimerItemComprado;

    public bool item2Comprado;

    private void Awake()
    {
        if (Instance == null) Instance = this;

        // Cargar desde el JSON al iniciar la escena
        PrimerItemComprado = SaveService.AutoClickBought;
        item2Comprado = SaveService.Tienda2Bought;
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
}
