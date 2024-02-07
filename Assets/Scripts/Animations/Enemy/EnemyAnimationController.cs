using System.Collections;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _enemyDamage;
    [SerializeField] private float _attackCooldown;

    private Animator _anim;
    private Health _health;
    private Health _playerHealth;
    private PlayerDetection _playerDetection;

    private float _currentCooldown = 0;
    private float _prevFrameXPosition;

    public bool IsEnemyKilled;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _health = GetComponent<Health>();
        _playerDetection = GetComponent<PlayerDetection>();
        _playerHealth = _player.GetComponent<Health>();
        _prevFrameXPosition = transform.position.x;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GlobalTags.BulletTag))
        {
            _anim.SetTrigger(AnimatorConstants._isHurtingProperty);
        }
    }

    private void Update()
    {
        _currentCooldown -= Time.deltaTime;

        if (_currentCooldown < 0)
        {
            _currentCooldown = 0;
        }

        //Death
        if (!_health.IsAlive)
        {
            _anim.SetBool(AnimatorConstants._isDeathProperty, true);
            StartCoroutine(WaitForEnemyDeathAnimation());
        }

        //Running
        _anim.SetBool(AnimatorConstants._isRunningProperty, Mathf.Abs(transform.position.x - _prevFrameXPosition) > float.Epsilon && !IsEnemyKilled);

        //Sprite Direction
        if (_player.transform.position.x > transform.position.x && !IsEnemyKilled)
        {
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }

        //Attack
        if (_playerDetection.YouAttacked && _playerHealth.IsAlive && !IsEnemyKilled)
        {
            _anim.SetBool(AnimatorConstants._isAttackedProperty, true);
            _player.GetComponent<Animator>().SetTrigger(AnimatorConstants._isHurtingProperty);

            if (_currentCooldown <= 0)
            {
                _player.GetComponent<Health>().TakeDamage(_enemyDamage);
                _currentCooldown = _attackCooldown;
            }
        }
        else
        {
            _anim.SetBool(AnimatorConstants._isAttackedProperty, false);
        }

        _prevFrameXPosition = transform.position.x;
    }

    IEnumerator WaitForEnemyDeathAnimation()
    {
        IsEnemyKilled = true;
        yield return new WaitForSecondsRealtime(2.0f);
        Statistics.EnemiesKilled++;
        Destroy(gameObject);
    }
}
