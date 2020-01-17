using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public int damage = 1;
    public float speed = 1;
    public float lifeTime = 5;
    public Rigidbody2D rb2D;

    protected virtual void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        ITakeDamage takeDamage = collision.gameObject.GetComponent<ITakeDamage>();
        if (takeDamage != null)
        {
            takeDamage.TakeDamage(damage);
        }
    }

    protected virtual void Update()
    {
        rb2D.velocity = transform.right * speed;
    }
}
