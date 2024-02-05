using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class AnimationController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _deathCanvas;
    [SerializeField] private GameObject _GameCanvas;


    public float _lastDirection;
   
    private Animator anim;
    private PlayerInput input;
    private Health health;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
        _playerTransform = GetComponent<Transform>();
        health = GetComponent<Health>();
    }

    private void Update()
    {
        //Running
        if (!input.horizontalDirection.IsEqualsZero())
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        //Jumping
        if (input.isJumpButtonPressed)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }

        //Shooting
        if (Input.GetButtonDown(GlobalStringVars.FIRE_1))
        {
            anim.SetTrigger("Shoot");
        }

        //Die
        if (!health.isAlive)
        {
            anim.SetBool("isDeath", true);
            StartCoroutine(waitForAnimation());
        }
                

        //Sprite Direction
        if (input.horizontalDirection > 0)
        {
            _lastDirection = 0.2f;
            _playerTransform.localScale = new Vector2(_lastDirection, 0.2f);
        }
        else if (input.horizontalDirection < 0)
        {
            _lastDirection = -0.2f;
            _playerTransform.localScale = new Vector2(_lastDirection, 0.2f);
        }
    }

    public void GetDamageAnimation()
    {
        anim.SetTrigger("Hurt");
    }

    IEnumerator waitForAnimation()
    {
        yield return new WaitForSecondsRealtime(2.0f);

        _GameCanvas.SetActive(false);
        _deathCanvas.SetActive(true);
        Statistics._livesUsed++;
    }
}
