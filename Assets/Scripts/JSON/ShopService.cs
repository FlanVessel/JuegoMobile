public static class ShopService
{
    public static bool IsBought(int itemId)
    {
        var data = SaveRepository.Data;

        return itemId switch
        {
            1 => data.autoClickBought,
            2 => data.tienda2Bought,
            3 => data.tienda3Bought,
            4 => data.tienda4Bought,
            5 => data.tienda5Bought,
            6 => data.tienda6Bought,
            _ => false
        };
    }

    public static void Buy(int itemId)
    {
        var data = SaveRepository.Data;

        switch (itemId)
        {
            case 1: data.autoClickBought = true; break;
            case 2: data.tienda2Bought = true; break;
            case 3: data.tienda3Bought = true; break;
            case 4: data.tienda4Bought = true; break;
            case 5: data.tienda5Bought = true; break;
            case 6: data.tienda6Bought = true; break; 
        }

        SaveRepository.Save();
    }
}
