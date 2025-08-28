using System.Collections.Generic;
using UnityEngine;

// Enum for different types of bullets
public enum BulletType { PNormal, PHoming, PSpread }

public class BulletManagerPool : MonoBehaviour
{
    // Serializable class to define a bullet pool in the Inspector
    [System.Serializable]
    public class BulletPool
    {
        public BulletType type;       // The type of bullet this pool represents
        public GameObject prefab;     // The prefab to instantiate for this pool
        public int size;              // How many bullets to pre-create
    }

    [SerializeField] private List<BulletPool> bulletPools; // List of bullet pools editable in Inspector

    // Dictionary to map bullet type -> Queue of bullets for pooling
    private Dictionary<BulletType, Queue<GameObject>> poolDictionary;

    void Start()
    {
        // Initialize the dictionary
        poolDictionary = new Dictionary<BulletType, Queue<GameObject>>();

        // For each bullet pool defined in Inspector
        foreach (var pool in bulletPools)
        {
            Queue<GameObject> queue = new Queue<GameObject>();

            // Pre-instantiate bullets for this pool
            for (int i = 0; i < pool.size; i++)
            {
                GameObject bullet = Instantiate(pool.prefab); // Create bullet
                bullet.SetActive(false);                      // Deactivate it
                queue.Enqueue(bullet);                        // Add to the queue
            }

            // Add the queue to the dictionary under the bullet type
            poolDictionary.Add(pool.type, queue);
        }
    }

    // Get a bullet from the pool of a specific type
    public GameObject GetBullet(BulletType type)
    {
        var queue = poolDictionary[type];  // Get the queue for this type
        var bullet = queue.Dequeue();      // Take a bullet from the front
        bullet.SetActive(true);            // Activate it
        queue.Enqueue(bullet);             // Put it back at the end
        return bullet;                     // Return it to the caller
    }
}
