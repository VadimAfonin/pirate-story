public static class Statistics
{
    public static int CoinsCollectedTotal;
    public static int EnemiesKilledTotal;
    public static int StarsforLevel;
    public static int CoinsCollected;
    public static int EnemiesKilled;
    public static int LivesUsed;

    public static float LevelPercent;

    public static void RefreshStats()
    {
        CoinsCollectedTotal += CoinsCollected;
        EnemiesKilledTotal += EnemiesKilled;
        CoinsCollected = 0;
        EnemiesKilled = 0;
    }

    public static void ResetStatsOnLevel()
    {
        CoinsCollected = 0;
        EnemiesKilled = 0;
    }
}