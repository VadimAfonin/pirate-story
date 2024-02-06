using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _deathCanvas;
    [SerializeField] private GameObject _GameCanvas;

    private Animator _anim;
    private PlayerInput _input;
    private Health _health;

    public float LastDirection;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _input = GetComponent<PlayerInput>();
        _playerTransform = GetComponent<Transform>();
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        //Running
        if (!_input.HorizontalDirection.IsEqualsZero())
        {
            _anim.SetBool(AnimatorConstants._isRunningProperty, true);
        }
        else
        {
            _anim.SetBool(AnimatorConstants._isRunningProperty, false);
        }

        //Jumping
        if (_input.IsJumpButtonPressed)
        {
            _anim.SetBool(AnimatorConstants._isJumpingProperty, true);
        }
        else
        {
            _anim.SetBool(AnimatorConstants._isJumpingProperty, false);
        }

        //Shooting
        if (Input.GetButtonDown(GlobalStringVars.Fire1))
        {
            _anim.SetTrigger(AnimatorConstants._isShootingProperty);
        }

        //Die
        if (!_health.IsAlive)
        {
            _anim.SetBool(AnimatorConstants._isDeathProperty, true);
            StartCoroutine(WaitForPlayerDeathAnimation());
        }

        //Sprite Direction
        if (_input.HorizontalDirection > 0)
        {
            LastDirection = 0.2f;
            _playerTransform.localScale = new Vector2(LastDirection, 0.2f);
        }
        else if (_input.HorizontalDirection < 0)
        {
            LastDirection = -0.2f;
            _playerTransform.localScale = new Vector2(LastDirection, 0.2f);
        }
    }

    public void GetDamageAnimation()
    {
        _anim.SetTrigger(AnimatorConstants._isHurtingProperty);
    }

    IEnumerator WaitForPlayerDeathAnimation()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        _GameCanvas.SetActive(false);
        _deathCanvas.SetActive(true);
        Statistics.LivesUsed++;
    }
}
