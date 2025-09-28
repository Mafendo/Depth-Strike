using System;
using UnityEngine;

public class MineExplodingGun : GunController
{

    // Update is called once per frame
    [SerializeField] HealthSystem MineHealth;

    void Awake()
    {
        MineHealth.OnDeath += Shoot;
        base.BulletManagerPoolsScript = FindAnyObjectByType<BulletManagerPool>();
        if (BulletManagerPoolsScript == null)
        {
            Debug.LogError("bulletPool IS mISSING");
        }
    }


}
