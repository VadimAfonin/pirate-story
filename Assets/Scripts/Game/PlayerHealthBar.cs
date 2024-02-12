using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Image _playerHealthImage;
    [SerializeField] private GameObject _deathCanvas;
    [SerializeField] private GameObject _GameCanvas;
    [SerializeField] private PlayerHealth _player;

    private bool _isCoroutineStarted = false;

    private void Update()
    {
        _playerHealthImage.fillAmount = _player.HealthPercent;

        if (!_player.PlayerIsAlive && !_isCoroutineStarted)
        {
            StartCoroutine(WaitForDeathCanvas());
            _isCoroutineStarted = true;
        }
    }

    IEnumerator WaitForDeathCanvas()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        _GameCanvas.SetActive(false);
        Time.timeScale = 0;
        _deathCanvas.SetActive(true);
        Statistics.LivesUsed++;
    }
}
