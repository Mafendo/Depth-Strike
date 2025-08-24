

using Unity.VisualScripting;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float startPos;
    private float length;
    [SerializeField] GameObject cam;
    [SerializeField] float ParallaxFactor;



    private void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    private void Update()
    {
        float temp = cam.transform.position.x * (1 - ParallaxFactor);
        float distance = cam.transform.position.x * ParallaxFactor;
       transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        
         // If camera moved outside sprite, reposition
        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;



    }
}
