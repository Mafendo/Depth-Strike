using TMPro;
using UnityEngine;

public class Player : HealthSystem
{
    [SerializeField] private TextMeshPro healthText;


    protected override void Start()
    {
        base.Start(); // This ensures currentHealth = maxHealth runs
        OnHealthChanged += UpdateHealthText;
        UpdateHealthText();
    }
    protected override void Die()
    {
        Debug.Log("Player died!");
        // Show Game Over screen, etc.
    }

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = maxHealth + "/" + GetHealth();
        }
    }


}
