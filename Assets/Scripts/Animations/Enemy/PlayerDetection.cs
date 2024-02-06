using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _attackDistance;

    private EnemyAnimationController _enemyAnimatorController;

    private bool _youVisible = false;

    public bool YouAttacked = false;

    private void Awake()
    {
        _enemyAnimatorController = GetComponent<EnemyAnimationController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals(GlobalTags.PlayerTag))
        {
            _youVisible = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals(GlobalTags.PlayerTag))
        {
            _youVisible = false;
        }
    }

    private void Update()
    {
        if (_youVisible && !_enemyAnimatorController.IsEnemyKilled)
        {
            AttackPlayer();
        }
    }

    private void FixedUpdate()
    {
        YouAttacked = (_playerTransform.position - transform.position).sqrMagnitude < _attackDistance;
    }

    private void AttackPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, _playerTransform.position, _enemySpeed * Time.deltaTime);
    }
}
