using System.Numerics;

public static class CurrencyService
{
    public static BigInteger Points
    {
        get => BigInteger.Parse(SaveRepository.Data.points);
        set => SaveRepository.Data.points = value.ToString();
    }

    public static void Add(BigInteger amount)
    {
        Points += amount;
        SaveRepository.Save();
    }

    public static bool TrySpend(BigInteger cost)
    {
        if (Points < cost)
        return false;

        Points -= cost;
        SaveRepository.Save();
        return true;
    }
}
