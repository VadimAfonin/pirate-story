using UnityEngine;

public class Storage : MonoBehaviour
{
    public const string LevelKey = "level_stars_count_{0}";

    public static void SetStarsCountToPrefs(int starsQuant, int levelNum)
    {
        PlayerPrefs.SetInt(GetLevelKeyForPrefs(levelNum), starsQuant);
    }

    public static int GetStarsCountFromPrefs(int levelNum)
    {
        return PlayerPrefs.GetInt(GetLevelKeyForPrefs(levelNum));
    }

    private static string GetLevelKeyForPrefs(int levelNum)
    {
        return string.Format(LevelKey, levelNum);
    }
}