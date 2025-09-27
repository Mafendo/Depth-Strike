using System;
using UnityEngine;

public class EnemyGunController : GunController
{
    [SerializeField] float fireCooldown = 2f;
    [SerializeField] HealthSystem healthSystem;
    float timer;
    private bool isDead = false;
    void Awake()
    {
        healthSystem.OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        isDead = true;
    }
    void Update()
    {
        timer += Time.deltaTime;
        // Debug.Log(timer);
        if (timer > fireCooldown)
        {
            if (!isDead)
            {
                Shoot();
            }


            timer = 0;
        }

    }


}
