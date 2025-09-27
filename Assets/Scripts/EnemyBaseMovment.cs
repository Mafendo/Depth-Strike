using UnityEngine;


public abstract class EnemyBaseMovment : MonoBehaviour
{
    [SerializeField] protected GunController gunController;
    [SerializeField] protected float speed = 2f;
    protected virtual Vector3 CalcDirection(Vector3 targetPostion, Vector3 ownPostion)
    {
        return targetPostion - ownPostion;
    }
}
