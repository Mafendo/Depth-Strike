using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class GunController : MonoBehaviour
{
    public BulletManagerPool BulletManagerPoolsScript;
    [SerializeField] protected List<ShootPort> shootPorts;


    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected int damage;
    private protected Vector3 direction;


    protected virtual void Shoot()
    {
        foreach (var port in shootPorts)
        {
            GameObject bullet = BulletManagerPoolsScript.GetBullet(port.bulletType);

            bullet.transform.position = port.spawnPoint.position;
            bullet.transform.rotation = Quaternion.identity; // or based on port direction
            bullet.SetActive(true);

            BulletBase bulletScript =bullet.GetComponent<BulletBase>();
            bulletScript.direction = port.direction;

        }
    }


    protected virtual void Direction()
    {
        // shared shooting logic (instantiate or pool bullets, set speed etc.)
        Debug.Log("Direction: nothing in here");
    }

}

