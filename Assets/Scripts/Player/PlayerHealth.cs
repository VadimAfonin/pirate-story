using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private float _maxHealth;
    [SerializeField] private GameObject _deathCanvas;
    [SerializeField] private GameObject _gameCanvas;

    private PlayerAnimationController _playerAnim;

    private float _currentHealth;

    public bool PlayerIsAlive;

    public float HealthPercent => Mathf.Clamp01(_currentHealth / _maxHealth);

    private void Awake()
    {
        _playerAnim = GetComponent<PlayerAnimationController>();
        _currentHealth = _maxHealth;
        PlayerIsAlive = true;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        CkeckPlayerIsAlive();
    }    

    public bool CkeckPlayerIsAlive()
    {
        if (_currentHealth > 0)
        {
            return PlayerIsAlive;
        }
        else
        {
            _playerAnim.PlayerDeathAnimation();
            StartCoroutine(WaitForPlayerDeathAnimation());
            Statistics.LivesUsed++;
            return !PlayerIsAlive;
        }
    }

    IEnumerator WaitForPlayerDeathAnimation()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        _gameCanvas.SetActive(false);
        _deathCanvas.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GlobalTags.DeathTriggerTag))
        {
            _gameCanvas.SetActive(false);
            _deathCanvas.SetActive(true);
            Statistics.LivesUsed++;
        }
    }
}
