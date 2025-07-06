using UnityEngine;
public enum BulletOwner
{
    Player,
    Enemy,
    non
}
public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public BulletOwner owner;
    public int damage;
    public Color color;

    [SerializeField] private SpriteRenderer bulletSpriteRenderer;


    public void Initialize(Vector3 direction, float speed, int damage, BulletOwner owner)
    {
        this.direction = direction;
        this.speed = speed;
        this.damage = damage;
        this.owner = owner;

        ChangeVisuals(); // or other setup
    }
    private void ChangeVisuals()
    {



        if (owner == BulletOwner.Player)
            color = Color.purple;
        else if (owner == BulletOwner.Enemy)
            color = Color.red;

        bulletSpriteRenderer.color = color;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {

        IDamageable target = other.GetComponent<IDamageable>();

        if ((owner == BulletOwner.Player && other.CompareTag("Player")) ||
            (owner == BulletOwner.Enemy && other.CompareTag("Enemy")))
            return; // Skip damaging friendly targets
        target.TakeDamage(damage);

        gameObject.SetActive(false); // Deactivate the bullet


    }
}
