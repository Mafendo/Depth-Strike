using Unity.VisualScripting;
using UnityEngine;


public class Bullet : MonoBehaviour
{


    public float speed = 10f;
    public Vector3 direction;
    [SerializeField] Collider a;
      [SerializeField] Collider b;

    void Start()
    {
       

        Physics.IgnoreCollision(a, b);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("bullet hit the:" + other.gameObject.name);
        gameObject.SetActive(false);
    }


}
