using UnityEngine;
using TMPro;


public class Enemy : HealthSystem
{

        [SerializeField] private TextMeshPro healthText;
        protected override void Start()
        {
                base.Start(); // This ensures currentHealth = maxHealth runs
                OnHealthChanged += UpdateHealthText;
                UpdateHealthText();
        }


        void UpdateHealthText()
        {
                if (healthText != null)
                {
                        healthText.text = "enemy:"+maxHealth + "/" + GetHealth();
                }
        }

        protected override void Die()
        {
                // Enemy-specific death logic
                Debug.Log("Enemy died!");
                Destroy(gameObject);
        }
}
