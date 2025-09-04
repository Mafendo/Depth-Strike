using UnityEngine;


public abstract class EnemyBaseMovment : MonoBehaviour
{
    [SerializeField] protected GunController gunController;
    protected virtual Vector3 CalcDirection(Vector3 targetPostion, Vector3 ownPostion)
    {
        return targetPostion - ownPostion;
    }
}
