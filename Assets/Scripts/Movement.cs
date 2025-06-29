using System;
using Unity.Mathematics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody rb;
    public float speedChangeAmout;
    public float maxForwadSpeed;
    public float maxBackwardsSpeed;

    private float currSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))

        {
            currSpeed -= speedChangeAmout;
            currSpeed = Mathf.Clamp(currSpeed, maxBackwardsSpeed, maxForwadSpeed);


        rb.linearVelocity = transform.forward * currSpeed;
        }
      

    }

}
