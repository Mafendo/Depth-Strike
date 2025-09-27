using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class HealthSystem : MonoBehaviour, IDamageable
{ 
    public event Action OnHealthChanged;
    [SerializeField] protected int maxHealth = 100;
    protected int currentHealth;


    public event Action OnDeath;
    protected virtual void Start()
    {

        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(int amount)
    {
        currentHealth -= amount;

        OnHealthChanged?.Invoke();

        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
            Die();
        }
    }
    public int GetHealth()
    {
        return currentHealth;
    }
    protected abstract void Die(); // force subclasses to implement their own death logic
}
