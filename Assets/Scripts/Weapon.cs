using UnityEngine;

public abstract class Weapon : PickableObject, IUsable
{
    public GameObject projectile;
    public Transform projectileSocket;
    public float fireRate = 1.0f;

    float nextFire;

    public virtual void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(projectile, projectileSocket.position, projectileSocket.rotation);
        }
    }

    public void Use()
    {
        Shoot();
    }
}
