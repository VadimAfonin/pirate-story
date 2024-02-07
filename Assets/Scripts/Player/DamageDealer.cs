using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GlobalTags.DamageableTag))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}
