using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _bulletSpeed;

    private AnimationController ac;

    private void Awake()
    {
        ac = GetComponent<AnimationController>();
    }

    public void Shoot(float direction)
    {
        GameObject currentBullet = Instantiate(_bullet, _firePoint.position, Quaternion.identity);
        Rigidbody2D bulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

        if (ac._lastDirection > 0)
        {
            bulletVelocity.velocity = new Vector2(_bulletSpeed * 1, bulletVelocity.velocity.y);
        }
        else
        {
            bulletVelocity.velocity = new Vector2(_bulletSpeed * -1, bulletVelocity.velocity.y);
        }
    }
}
