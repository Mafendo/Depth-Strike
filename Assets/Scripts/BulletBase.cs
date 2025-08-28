using UnityEngine;
// Enum that describes who the bullet belongs to
public enum BulletOwner
{
    Player,// Bullet fired by the player
    Enemy,// Bullet fired by an enemy
    non // No owner (example: neutral projectile)
}


// Abstract base class for all bullets
public abstract class BulletBase : MonoBehaviour
{

    public Vector3 direction; 
    public float speed;
    public BulletOwner owner;
    public int damage;
    public Color color;
    [SerializeField] private SpriteRenderer bulletSpriteRenderer;

// Initializes the bullet with properties
    public virtual void Initialize(Vector3 direction, float speed, int damage, BulletOwner owner)
    {
        this.direction = direction;
        this.speed = speed;
        this.damage = damage;
        this.owner = owner;


    }

// Defines how the bullet moves (e.g., straight, homing, zig-zag)
    protected abstract void Move();

    protected virtual void Update()
    {
        Move();
    }


    
    protected virtual void OnTriggerEnter(Collider other)
    {
        IDamageable target = other.GetComponent<IDamageable>();

        // prevent friendly fire
        if ((owner == BulletOwner.Player && other.CompareTag("Player")) ||
            (owner == BulletOwner.Enemy && other.CompareTag("Enemy")))
            return;

        // If the object can take damage → apply damage
        target?.TakeDamage(damage);
        gameObject.SetActive(false);
    }
}


