using System;
using UnityEngine;

public class FunktionParentGrabber : MonoBehaviour
{
    [SerializeField] RotatePivotPoint gameObjectParrent;
    public void Flip()
    {
        gameObjectParrent.Flip();
        
    }
}
