using System.Collections;
using Unity.VisualScripting;
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
    private float initialSpeed;
    [SerializeField] GameObject[] bulletSpriteRenderers;
    [SerializeField] GameObject explotionAnim;


    [SerializeField] float lifeTime = 2f;

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
        Debug.Log(other.name);


        this.speed = 0;
        DeactivatedBullet();
    }
    private void Awake()
    {
        initialSpeed = speed;
    }
    private async void OnEnable()
    {
         foreach (GameObject sprite in bulletSpriteRenderers)
        {
            sprite.SetActive(true);
        }
        explotionAnim.SetActive(false);
        speed = initialSpeed;



        // Wait for lifetime
        await System.Threading.Tasks.Task.Delay((int)(lifeTime * 1000));
        gameObject.SetActive(false);
    }

    private void DeactivatedBullet()
    {
        foreach (GameObject sprite in bulletSpriteRenderers)
        {
            sprite.SetActive(false);
        }

        explotionAnim.SetActive(true);
        WaitForExplotionAndDeactivate();


    }

    private IEnumerator WaitForExplotionAndDeactivate()
    {

        Animator anim = explotionAnim.GetComponent<Animator>();

        if (anim != null)
        {
            // Wait until the animation has finished playing (normalizedTime >= 1)
            while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
            {
                yield return null; // wait for next frame
            }
        }

        // Finally, deactivate the bullet
        gameObject.SetActive(false);
    }
}


