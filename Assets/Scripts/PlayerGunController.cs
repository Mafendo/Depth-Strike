using UnityEngine;

public class PlayerGunController : GunController
{
    
    void Update()
    {
        InputHandler();
    }

    void InputHandler()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Shoot();
        }
    }

    protected override void Shoot()
    {
        GameObject bullet = BulletManagerPoolsScript.GetBullet();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
        bullet.SetActive(true);

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.Initialize(direction,bulletSpeed,damage,BulletOwner.Player);
        


    }
}
