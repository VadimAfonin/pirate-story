using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AnimationController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _enemyDamage;
    [SerializeField] private float _attackCooldown;

    private Animator anim;
    private Health health;
    private Health _playerHealth;
    private Rigidbody2D rb;
    private PlayerDetection pd;
    private float currentCooldown = 0;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
        pd = GetComponent<PlayerDetection>();
        _playerHealth = _player.GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            anim.SetTrigger("Hurt");
        }
    }

    private void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown < 0)
        {
            currentCooldown = 0;
        }

        //Death
        if (!health.isAlive)
        {
            anim.SetBool("isDeath", true);
            StartCoroutine(waitForAnimation());
        }

        //Running
        anim.SetBool("isRunning", !rb.velocity.x.IsEqualsZero());

        //Attack
        if (pd.youAttacked && _playerHealth.isAlive)
        {
            anim.SetBool("youAttacked", true);
            _player.GetComponent<Animator>().SetTrigger("Hurt");

            if (currentCooldown <= 0)
            {
                _player.GetComponent<Health>().TakeDamage(_enemyDamage);
                currentCooldown = _attackCooldown;
            }
        }
        else
        {
            anim.SetBool("youAttacked", false);
        }
    }

    IEnumerator waitForAnimation()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        Statistics._enemiesKilled++;
        Destroy(gameObject);
    }
}
