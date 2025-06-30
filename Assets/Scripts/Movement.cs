using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    private Rigidbody rb;

    private Vector3 movement;
    public float speed = 1f;
    public float lerpFactor = 0.3f;





    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        InputHandler();

    }

    void FixedUpdate()
    {

        MovementHandler();
    }




    void MovementHandler()
    {
        Vector3 targetPosition = rb.position + new Vector3(movement.x, movement.y, 0).normalized * speed * Time.fixedDeltaTime;
        Vector3 lerpPos = Vector3.Lerp(rb.position, targetPosition, lerpFactor);
        rb.MovePosition(lerpPos);
    }

    void InputHandler()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal == 0 && vertical == 0)
        {
            movement = Vector3.zero;
           
            return;
        }
        movement = new Vector3(horizontal, vertical, 0);



    }
}
