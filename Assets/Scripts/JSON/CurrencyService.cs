using System.Numerics;

//Maneja Puntos (Economia)
public static class CurrencyService
{
    //Lee/escribe puntos
    public static BigInteger Points
    {
        get => BigInteger.Parse(SaveRepository.Data.points);  //lee puntos del save
        set => SaveRepository.Data.points = value.ToString(); //escribe puntos en la RAM del Save
    }

    //Suma puntos y guarda en disco
    public static void Add(BigInteger amount)
    {
        Points += amount;
        SaveRepository.Save();
    }

    // Intenta gastar puntos 
    public static bool TrySpend(BigInteger cost)
    {
        if (Points < cost)
        return false;

        Points -= cost;
        SaveRepository.Save();
        return true;
    }
}
