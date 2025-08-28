using UnityEngine;

public class ShootPort : MonoBehaviour
{
    public Transform spawnPoint; // where bullet appears
    public Vector3 direction = Vector3.right; // direction to shoot
    public BulletType bulletType = BulletType.PNormal; // which bullet type

}
