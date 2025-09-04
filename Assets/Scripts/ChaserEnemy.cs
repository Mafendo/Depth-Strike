using System.Collections;
using UnityEngine;

public class ChaserEnemy : EnemyBaseMovment
{
    [SerializeField] GameObject targetPostion;
    [SerializeField] GameObject ownPostion;
    [SerializeField] float speed = 2f;
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
            // Remove Y component
            direction.y = 0;

        }
        transform.position += direction.normalized * speed * Time.deltaTime;

        
    }
}
