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

    protected override void Shoot()
    {
        GameObject bullet = BulletManagerPoolsScript.GetBullet();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
        bullet.SetActive(true);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
         bulletScript.Initialize(direction,bulletSpeed,damage,BulletOwner.Enemy);

    }
}
