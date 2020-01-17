using UnityEngine;

public class Bullet : Projectile
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        Destroy(gameObject);
    }
}
