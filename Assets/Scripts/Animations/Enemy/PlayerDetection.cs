using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _attackDistance;

    private bool _youVisible = false;

    private const string PlayerTag = "Player";

    public bool YouAttacked = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals(PlayerTag))
        {
            _youVisible = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals(PlayerTag))
        {
            _youVisible = false;
        }
    }    

    private void Update()
    {
        if (_youVisible)
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
