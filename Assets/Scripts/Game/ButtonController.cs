using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private Sprite _isMutedSprite;
    private Sprite _nonMutedSprite;
    private Image _img;

    private static bool _isMuted;

    private void Awake()
    {
        _img = GetComponent<Image>();
        _isMuted = false;
        _nonMutedSprite = Resources.Load<Sprite>("PNG/UI/btn/misic");
        _isMutedSprite = Resources.Load<Sprite>("PNG/UI/btn/music_off");
    }

    public void OnHomeButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnMuteButtonClick()
    {
        _isMuted = !_isMuted;
        AudioListener.volume = _isMuted ? 0 : 1;
        _img.sprite = _isMuted ? _isMutedSprite : _nonMutedSprite;
    }

    public void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        Statistics.ResetStatsOnLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PauseController.IsPaused = false; ;
    }

    public void OnNextLevelButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
        Statistics.RefreshStats();
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
