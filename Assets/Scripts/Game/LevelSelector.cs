using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] GetStarsCountOnMenu _starsPicController;
    [SerializeField] private int _buildIndex;

    private void Awake()
    {
        Transform LevelIndex = transform.GetChild(0);
        LevelIndex.GetComponent<TMP_Text>().text = _buildIndex.ToString();
        _starsPicController.SetPicStars(Storage.GetStarsCountFromPrefs(_buildIndex));
        var button = GetComponent<Button>();
        button.onClick.AddListener(OnLevelButtonClick);
    }

    void OnLevelButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_buildIndex);
    }
}
