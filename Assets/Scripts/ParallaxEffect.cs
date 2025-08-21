using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private float parallaxEffectSpeed = 0.5f;
    [SerializeField] private bool pixelSnap = true;
    [SerializeField] private float pixelsPerUnit = 100f;

    private Vector2 startPos;
    private Vector2 spriteSize;

    void Start()
    {
        startPos = transform.position;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        spriteSize = sr.bounds.size;
    }

    void FixedUpdate()
    {
        Vector2 cameraPos = cam.transform.position;

        Vector2 distance = cameraPos * parallaxEffectSpeed;
        Vector2 movement = cameraPos * (1 - parallaxEffectSpeed);

        Vector2 newPos = startPos + distance;

        // Optional: snap to pixel grid
        if (pixelSnap)
        {
            float pixelSize = 1f / pixelsPerUnit;
            newPos.x = Mathf.Round(newPos.x / pixelSize) * pixelSize;
            newPos.y = Mathf.Round(newPos.y / pixelSize) * pixelSize;
        }

        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);

        // Repeat (wrap) horizontally
        while (movement.x > startPos.x + spriteSize.x)
        {
            startPos.x += spriteSize.x;
        }
        while (movement.x < startPos.x - spriteSize.x)
        {
            startPos.x -= spriteSize.x;
        }

        // Repeat (wrap) vertically (optional)
        while (movement.y > startPos.y + spriteSize.y)
        {
            startPos.y += spriteSize.y;
        }
        while (movement.y < startPos.y - spriteSize.y)
        {
            startPos.y -= spriteSize.y;
        }
    }
}
