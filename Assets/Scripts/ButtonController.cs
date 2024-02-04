using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private Sprite _isMutedSprite;
    private Sprite _nonMutedSprite;
    private static bool _isMuted;
    private Image img;


    private void Awake()
    {
        var camera = FindObjectOfType<Camera>();
        img = GetComponent<Image>();
        _isMuted = false;
        _nonMutedSprite = Resources.Load<Sprite>("PNG/UI/btn/misic");
        _isMutedSprite = Resources.Load<Sprite>("PNG/UI/btn/music_off");
    }

    public void onHomeButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void omMuteButtonClick()
    {
        _isMuted = !_isMuted;
        AudioListener.volume = _isMuted ? 0 : 1;
        img.sprite = _isMuted ? _isMutedSprite : _nonMutedSprite;
    }

    public void onRestartButtonClick()
    {
        Time.timeScale = 1;
        Statistics.ResetStatsOnLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnNextLevelButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
        Statistics.RefreshStats();
    }
}
