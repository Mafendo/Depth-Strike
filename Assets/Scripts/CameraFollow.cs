using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Vector3 offset = new Vector3(0f, 0f, -10f);
    [SerializeField] Transform target;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 rawPosition = target.position + offset;

            // Snap to pixel grid based on your resolution
            float pixelsPerUnit = 100f; // or whatever your camera PPU is
            float pixelSize = 1f / pixelsPerUnit;

            rawPosition.x = Mathf.Round(rawPosition.x / pixelSize) * pixelSize;
            rawPosition.y = Mathf.Round(rawPosition.y / pixelSize) * pixelSize;

            transform.position = rawPosition;
        }
    }
}
