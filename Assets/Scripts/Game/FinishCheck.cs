using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishCheck : MonoBehaviour
{
    [SerializeField] private GameObject _gameCanvas;
    [SerializeField] private GameObject _ui_popup;
    [SerializeField] private GetStarsCountOnMenu _starsPicController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals(GlobalTags.PlayerTag))
        {
            _gameCanvas.SetActive(false);
            _ui_popup.SetActive(true);
            int LevelStarsCount = StarsCalculator.SetStarsCountFromCoinsCountOnLevel(Statistics.LevelPercent);
            Storage.SetStarsCountToPrefs(LevelStarsCount, SceneManager.GetActiveScene().buildIndex);
            _starsPicController.SetPicStars(LevelStarsCount);
        }
    }
}