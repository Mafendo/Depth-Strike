using UnityEngine;
using TMPro;
using System.Collections;


public class Enemy : HealthSystem
{

        [SerializeField] private TextMeshPro healthText;
        [SerializeField] GameObject MeshHolder;
        [SerializeField] GameObject ExplotionAnim;
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
                        healthText.text = "enemy:" + maxHealth + "/" + GetHealth();
                }
        }

        protected override void Die()
        {
                // Enemy-specific death logic
                Debug.Log("Enemy died!");
                MeshHolder.SetActive(false);
                ExplotionAnim.SetActive(true);
              StartCoroutine(WaitForAnimationAndDestroy());




        }
        private IEnumerator WaitForAnimationAndDestroy()
        {
                Animator anim = ExplotionAnim.GetComponent<Animator>();
                if (anim != null)
                {
                        // Wait for the current state to finish
                        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
                        float length = stateInfo.length;
                        Debug.Log("wait");
                        yield return new WaitForSeconds(length);
                }
                Debug.Log("now we die");
                Destroy(gameObject);

        }
}
