using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public BulletManagerPool BulletManagerPoolsScript;
    [SerializeField] Transform firePoint;
    [SerializeField] float bulletSpeed = 100f;


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

    void Shoot()
    {
        GameObject bullet = BulletManagerPoolsScript.GetBullet();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
        bullet.SetActive(true);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.speed = bulletSpeed;
       

    }
}

