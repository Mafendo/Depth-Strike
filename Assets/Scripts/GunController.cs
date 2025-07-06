using Unity.VisualScripting;
using UnityEngine;

public abstract class GunController : MonoBehaviour
{
    public BulletManagerPool BulletManagerPoolsScript;
     [SerializeField] protected Transform firePoint;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected int damage;
    [SerializeField] protected Vector3 direction;
    


    protected virtual void Shoot()
    {
        // shared shooting logic (instantiate or pool bullets, set speed etc.)
        Debug.Log("shoot nothing in here");
    }

}

