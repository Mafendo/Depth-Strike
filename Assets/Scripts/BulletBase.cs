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
    [SerializeField] GameObject[] bulletSpriteRenderers;
    [SerializeField] GameObject explotionAnim;
    [SerializeField] GameObject TrailParent;

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
        DeactivatedBullet();
    }

    private async void OnEnable()
    {
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

        // Start coroutine to wait for trails to finish
        StartCoroutine(WaitForTrailAndDeactivate());
    }

    private IEnumerator WaitForTrailAndDeactivate()
    {
        // Optional: get all trail animators
        Animator[] trailAnimators = TrailParent.GetComponentsInChildren<Animator>();

        // Wait until all trail animations are done
        foreach (Animator anim in trailAnimators)
        {
            if (anim != null)
            {
                // Wait until the animation has finished playing (normalizedTime >= 1)
                while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
                {
                    yield return null; // wait for next frame
                }
            }
        }

        // Deactivate explosion (optional)
        explotionAnim.SetActive(false);

        // Finally, deactivate the bullet
        gameObject.SetActive(false);
    }
}


