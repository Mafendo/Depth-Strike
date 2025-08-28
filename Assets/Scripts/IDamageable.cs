using UnityEngine;
// Interface for all objects that can take damage
public interface IDamageable
{
    void TakeDamage(int amount);  // Must be implemented by damageable objects
}
