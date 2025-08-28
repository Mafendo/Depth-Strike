using UnityEngine;

public class EnemyGunController : GunController
{
    [SerializeField] float fireCooldown = 2f;
    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        // Debug.Log(timer);
        if (timer > fireCooldown)
        {
            Shoot();
            timer = 0;
        }

    }

    
}
