using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PatrollerEnemy : EnemyBaseMovment
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] private float reachThreshold = 0.1f; // how close counts as "reached"
    private Transform target;

    private bool isFlipped = false;
    [SerializeField] float rotationSpeed = 5f;
    private Quaternion targetRotation;
    [SerializeField] ShootPort shootPort;
    private int shootDircation;
    [SerializeField] HealthSystem healthSystem;
    private bool isDead = false;
    void Awake()
    {
        healthSystem.OnDeath += Ondeath;
    }
    private void Ondeath()
    {
        isDead = true;
        speed = 0;
    }                                               
    void Start()
    {

        // Start by going to point A
        target = pointA;
    }
    void Update()
    {

       
        // Move towards the current target
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);


        // If close enough to the target, switch
        if (Vector3.Distance(transform.position, target.position) < reachThreshold)
        {
            target = target == pointA ? pointB : pointA;
            FlipCharacter();
        }


        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    void FlipCharacter()
    {
        isFlipped = !isFlipped;
        shootDircation = isFlipped ? 1 : -1;
        shootPort.direction = new Vector3(shootDircation, 0, 0);
        targetRotation = Quaternion.Euler(0f, isFlipped ? -180f : 0f, 0f);
    }

}
