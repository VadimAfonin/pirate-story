using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AnimationController : MonoBehaviour
{
    private Animator anim;
    private Health health;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
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
        if (!health.isAlive)
        {
            anim.SetBool("isDeath", true);
        }
    }
}
