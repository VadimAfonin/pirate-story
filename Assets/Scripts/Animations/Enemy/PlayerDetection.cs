using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _attackDistance;

    private bool youVisible = false;
    public bool youAttacked = false;

    private const string PlayerTag = "Player";      

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals(PlayerTag))
        {
            youVisible = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals(PlayerTag))
        {
            youVisible = false;
        }
    }    

    private void AttackPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, _playerTransform.position, _enemySpeed * Time.deltaTime);        
    }

    private void Update()
    {
        if (youVisible)
        {
            AttackPlayer();
        }
    }

    private void FixedUpdate()
    {
        youAttacked = (_playerTransform.position - transform.position).sqrMagnitude < _attackDistance;
    }
}
