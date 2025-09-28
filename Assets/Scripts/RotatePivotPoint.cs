using Unity.Mathematics;
using UnityEditor.Tilemaps;
using UnityEngine;

public class RotatePivotPoint : MonoBehaviour
{
    [SerializeField] Quaternion maxRotationPivit;
    [SerializeField] Quaternion minRotationPivit;
    [SerializeField] float speed;
    private bool rotatingTowardsMax = true;
    private Quaternion targetRotation;


    // Update is called once per frame
    void Awake()
    {
        targetRotation = maxRotationPivit;
    }
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.deltaTime);

    }
    public void Flip()
    {
        rotatingTowardsMax = !rotatingTowardsMax;
        targetRotation = rotatingTowardsMax ? minRotationPivit : maxRotationPivit;
    }
}
