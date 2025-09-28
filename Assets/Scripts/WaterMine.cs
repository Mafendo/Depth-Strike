using System;
using System.Collections.Generic;
using UnityEngine;

public class WaterMine : HealthSystem
{

    [SerializeField] bool willExplode = false;

    protected override void Die()
    {
        Destroy(transform.gameObject);
        Debug.Log("mineExpolded");
    }
    
}
