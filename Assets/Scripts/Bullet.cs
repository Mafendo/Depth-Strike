using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 direction;



    // Initialize bullet with direction 
    public void Initialize(Vector3 dir)
    {
        direction = dir;



    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {

            Debug.Log("Bullet hit: " + other.gameObject.name);
            //gameObject.SetActive(false);
        }
       
      



    }
}
