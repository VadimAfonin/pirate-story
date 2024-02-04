using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;


    private float currentHealth;
    public bool isAlive;
    public float HealthPercent => Mathf.Clamp01(currentHealth / _maxHealth);

    private void Awake()
    {
        currentHealth = _maxHealth;
        isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;       
            
        
        CheckIsAlive();
    }

    public bool CheckIsAlive()
    {
        isAlive = currentHealth > 0;
        return isAlive; 
    }
}
