using UnityEngine;
using System.Numerics;
using System.Linq;
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
        }
    }

}
