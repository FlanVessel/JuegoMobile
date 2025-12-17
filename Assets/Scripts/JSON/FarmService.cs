// Progreso de granja (Nivel y produccion)
public static class FarmService
{
    public static int Level
    {
        get => SaveRepository.Data.granjaNivel;              // lee el nivel 
        set => SaveRepository.Data.granjaNivel = value;      // escribe el nivel
    }

    public static int ProductionPerSecond => Level;     //regla: nivel = puntos

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
