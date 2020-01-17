using UnityEngine;

public class Cannonball : Projectile
{
    [SerializeField] GameObject explosionEffect;
    [SerializeField] int explosionDamage;
    [SerializeField] float explosionRadius = 1.0f;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        explosionEffect.transform.localScale = Vector3.one * explosionRadius;
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D nearbyObject in colliders)
        {
            ITakeDamage damageableObject = nearbyObject.GetComponent<ITakeDamage>();
            if (damageableObject != null)
            {
                damageableObject.TakeDamage(explosionDamage);
            }

            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionRadius, transform.position, explosionRadius);
            }
        }

        Destroy(gameObject);
    }
}