using System.Collections.Generic;
using UnityEngine;

public class MineZone : MonoBehaviour
{
    private List<GameObject> objectsZone = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mine"))
        {
            Debug.Log(collision.name);
        }
    }
}
