using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalTags.DamageableTag))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}
