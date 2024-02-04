public static class Statistics
{
    public static int _coinsCollectedTotal;
    public static int _enemiesKilledTotal;
    public static int _starsforLevel;

    public static int _coinsCollected;
    public static int _enemiesKilled;
    public static int _livesUsed;
    public static float _levelPercent;



    public static void RefreshStats()
    {
        _coinsCollectedTotal += _coinsCollected;
        _enemiesKilledTotal += _enemiesKilled;
        _coinsCollected = 0;
        _enemiesKilled = 0;
    }

    public static void ResetStatsOnLevel()
    {
        _coinsCollected = 0;
        _enemiesKilled = 0;
    }
}