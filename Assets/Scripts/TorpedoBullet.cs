using UnityEngine;

public class TorpedoBullet : BulletBase
{
   protected override void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
