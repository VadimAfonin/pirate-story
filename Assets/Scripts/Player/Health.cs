using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;
    public bool IsAlive;

    public float HealthPercent => Mathf.Clamp01(_currentHealth / _maxHealth);

    private void Awake()
    {
        _currentHealth = _maxHealth;
        IsAlive = true;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        CheckIsAlive();
    }

    public bool CheckIsAlive()
    {
        IsAlive = _currentHealth > 0;
        return IsAlive;
    }
}
