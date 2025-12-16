public static class SaveRepository
{
    private static PlayerSave _data;

    public static PlayerSave Data
    {
        get
        {
            if (_data == null)
                _data = SaveStorage.Load();

            return _data;
        }
    }

    public static void Save()
    {
        SaveStorage.Save(Data);
    }

    public static void Reset()
    {
        _data = new PlayerSave();
        Save();
    }
}
