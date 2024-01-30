using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Level_Selector : MonoBehaviour
{
    [SerializeField] private int _buildIndex;
    [SerializeField] StarsPicController _starsPicController;

    private void Awake()
    {
        var index = transform.GetChild(0);
        index.GetComponent<TMP_Text>().text = _buildIndex.ToString();
        _starsPicController.SetPicStars(Storage.GetStars(_buildIndex));
        var button = GetComponent<Button>();
        button.onClick.AddListener(OnLevelButtonClick);
    }

    void OnLevelButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_buildIndex);
    }
}
