using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private Animator _anim;
    private PlayerInput _input;

    public float LastDirection = 0.2f;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _input = GetComponent<PlayerInput>();
        _playerTransform = GetComponent<Transform>();
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

    public void PlayerDeathAnimation()
    {
        _anim.SetBool(AnimatorConstants._isDeathProperty, true);
    }
}
