using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpOffset;
    [SerializeField] private float _playerSpeed;

    [Header("Settings")]
    [SerializeField] private AnimationCurve _accelerationCurve;
    [SerializeField] private Transform _groundColliderTransform;
    [SerializeField] private LayerMask _groundMask;

    private bool _isGrounded;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = _groundColliderTransform.position;
        _isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, _jumpOffset, _groundMask);
    }

    public void Move(float direction, bool isJumpButtonPressed)
    {
        if (isJumpButtonPressed)
        {
            Jump();
        }
        if (!direction.IsEqualsZero())
        {
            HorizontalMovement(direction);
        }
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
    }

    private void HorizontalMovement(float direction)
    {
        _rb.velocity = new Vector2(_accelerationCurve.Evaluate(direction), _rb.velocity.y);  //Evaluate для плавного разгона и торможения Игрока
    }
}