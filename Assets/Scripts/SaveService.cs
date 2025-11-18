using UnityEngine;
using System.Numerics;
using System.IO;

public class SaveService
{
    private static readonly string FileName = "player_save.json";
    private static string FullPath => Path.Combine(Application.persistentDataPath, FileName);

    private static PlayerSave _data;

    public static PlayerSave Data
    {
        get
        {
            if (_data == null)
                _data = LoadFromDisk();
            return _data;
        }
    }

    private static PlayerSave LoadFromDisk()
    {
        try
        {
            if (File.Exists(FullPath))
            {
                var json = File.ReadAllText(FullPath);
                var data = JsonUtility.FromJson<PlayerSave>(json);
                if (data == null) data = new PlayerSave();
                if (string.IsNullOrEmpty(data.points)) data.points = "0";
                return data;
            }
        }
        catch (System.Exception e)
        {
            Debug.LogWarning($"[SaveService] Load error: {e}");
        }

        return new PlayerSave();
    }

    public static void Save()
    {
        try
        {
            var json = JsonUtility.ToJson(Data, prettyPrint: true);
            var tmp = FullPath + ".tmp";
            File.WriteAllText(tmp, json);
            if (File.Exists(FullPath)) File.Delete(FullPath);
            File.Move(tmp, FullPath);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning($"[SaveService] Save error: {e}");
        }
    }

    public static BigInteger Points
    {
        get
        {
            if (!BigInteger.TryParse(Data.points, out var v))
                v = BigInteger.Zero;
            return v;
        }
        set
        {
            Data.points = value.ToString();
            Debug.Log("Este es el valor de: " + Data.points);
        }
    }

    public static void AddPoints(BigInteger delta)
    {
        Points = Points + delta;
    }

    public static bool TrySpend(BigInteger cost)
    {
        var current = Points;
        if (current < cost) return false;
        Points = current - cost;
        return true;
    }

    // ---- Compra única del primer item de tienda ----

    public static bool AutoClickBought
    {
        get => Data.autoClickBought;
        set => Data.autoClickBought = value;
    }

    public static bool Tienda2Bought
    {
        get => Data.tienda2Bought;
        set => Data.tienda2Bought = value;
    }

    public static bool Tienda3Bought
    {
        get => Data.tienda3Bought;
        set => Data.tienda3Bought = value;
    }

    public static bool Tienda4Bought
    {
        get => Data.tienda4Bought;
        set => Data.tienda4Bought = value;
    }

    public static bool Tienda5Bought
    {
        get => Data.tienda5Bought;
        set => Data.tienda5Bought = value;
    }

    public static bool Tienda6Bought
    {
        get => Data.tienda6Bought;
        set => Data.tienda6Bought = value;
    }

    public static int GranjaNivel
    {
        get => Data.granjaNivel;
        set => Data.granjaNivel = value;
    }

}
