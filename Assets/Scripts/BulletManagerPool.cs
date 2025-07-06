using System.Collections.Generic;
using UnityEngine;

public class BulletManagerPool : MonoBehaviour
{

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int poolSize = 10;

    //whole bullet pool
    private Queue<GameObject> pool = new Queue<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            pool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet()
    {
        GameObject bullet = pool.Dequeue();
        bullet.SetActive(true);
        pool.Enqueue(bullet); // immediately enqueue again so it stays in rotation
        return bullet;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
