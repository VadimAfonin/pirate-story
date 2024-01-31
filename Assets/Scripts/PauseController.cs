using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private GameObject _gameCanvas;

    public static bool _isPaused = false;
    public void OnPlayButtonClick()
    {
        _isPaused = false;
        Time.timeScale = 1;
        _pauseCanvas.SetActive(false);
        _gameCanvas.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPaused = true;
            Time.timeScale = 0;
            _gameCanvas.SetActive(false);
            _pauseCanvas.SetActive(true);
        }
    }
}
