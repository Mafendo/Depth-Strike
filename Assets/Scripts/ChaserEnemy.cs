using System.Collections;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;

public class ChaserEnemy : EnemyBaseMovment
{
    [SerializeField] GameObject targetPostion;
    [SerializeField] GameObject ownPostion;

    // Update is called once per frame
    private bool stopVerticalMovement = false;
    void Awake()
    {
        gunController.OnShoot += StopVertical;
    }
    private void StopVertical()
    {
        stopVerticalMovement = true;
        StartCoroutine(ResumeVerticalAfterDelay(1f)); // stop vertical for 1 second
    }

    private IEnumerator ResumeVerticalAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        stopVerticalMovement = false;
    }
    void Update()
    {
        Vector3 direction = CalcDirection(targetPostion.transform.position, ownPostion.transform.position);


        if (stopVerticalMovement)
        {
            return;

        }
        transform.position = Vector3.MoveTowards(transform.position, targetPostion.transform.position, speed * Time.deltaTime);


    }
}
