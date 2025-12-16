using UnityEngine;
using System.IO;

public static class SaveStorage
{
    private static readonly string FileName = "player_save.json";

    private static string FullPath => Path.Combine(Application.persistentDataPath, FileName);

    public static PlayerSave Load()
    {
        if (!File.Exists(FullPath))
        return new PlayerSave();

        var json = File.ReadAllText(FullPath);
        var data = JsonUtility.FromJson<PlayerSave>(json);

        return data ?? new PlayerSave();
    }

    public static void Save(PlayerSave data)
    {
        var json = JsonUtility.ToJson(data, true);
        File.WriteAllText(FullPath, json);
    }
}
