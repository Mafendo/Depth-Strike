using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaterMine : HealthSystem
{

    [SerializeField] bool willExplode = false;
    private SpriteRenderer mineHeadSprite;
    private Color oldcolor;
    private GameObject otherMines = GameObject.FindWithTag("Mine");
    [SerializeField] BoxCollider2D zoneCollider;
    protected override
    void Start()
    {
        base.Start();
        OnHealthChanged += OnHit;
        mineHeadSprite = gameObject.GetComponent<SpriteRenderer>();
        oldcolor = mineHeadSprite.color;
    }
    protected override void Die()
    {
        Destroy(transform.gameObject);
        Debug.Log("mineExpolded");




    }

    private void OnHit()
    {
        //Debug.Log("Mine GOT HIT");
        mineHeadSprite.color = new Color(0.898f, 0.561f, 0.216f, 1f);
        StartCoroutine(HitChangeColor(0.1f));

    }

    private IEnumerator HitChangeColor(float delay)
    {
        yield return new WaitForSeconds(delay);
        mineHeadSprite.color = oldcolor;
    }
}
