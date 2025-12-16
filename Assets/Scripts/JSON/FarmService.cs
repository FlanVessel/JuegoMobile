public static class FarmService
{
    public static int Level
    {
        get => SaveRepository.Data.granjaNivel;
        set => SaveRepository.Data.granjaNivel = value;
    }

    public static int ProductionPerSecond => Level;

    public static bool IsUnlocked => Level > 0;

    public static void Buy()
    {
        Level = 1;
        SaveRepository.Save();
    }

    public static void Upgrade()
    {
        if (Level >= 10) return;

        Level++;
        SaveRepository.Save();
    }
}
