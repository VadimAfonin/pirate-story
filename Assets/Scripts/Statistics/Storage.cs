using UnityEngine;

public class Storage : MonoBehaviour
{
    public static void SetStars(int starsQuant, int levelNum)
    {
        PlayerPrefs.SetInt(GetLevelKey(levelNum), starsQuant);
    }

    public static int GetStars(int levelNum)
    {
        return PlayerPrefs.GetInt(GetLevelKey(levelNum));
    }

    private static string GetLevelKey(int levelNum)
    {
        return string.Format(GlobalTags.LevelKey, levelNum);
    }
}
