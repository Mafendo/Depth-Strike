using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Vector3 offset = new Vector3(0f, 0f, -10f);
    [SerializeField] Transform target;

    [SerializeField] float maxYOffsetValue = 5f;
    [SerializeField] float minYOffsetValue = -5f;

    [SerializeField] float pixelsPerUnit = 100f; // Match your PPU

    void LateUpdate()
    {
        if (target == null) return;

        // Target position with offset
        Vector3 rawPosition = target.position + offset;

        // Clamp Y position inside limits
        rawPosition.y = Mathf.Clamp(rawPosition.y, minYOffsetValue, maxYOffsetValue);

        // Snap to pixel grid
        float pixelSize = 1f / pixelsPerUnit;
        rawPosition.x = Mathf.Round(rawPosition.x / pixelSize) * pixelSize;
        rawPosition.y = Mathf.Round(rawPosition.y / pixelSize) * pixelSize;

        transform.position = rawPosition;
    }
}
