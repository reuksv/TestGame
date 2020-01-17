using UnityEngine;

public class Enemy : Character
{
    public delegate void EnemyDiedAction();
    public static event EnemyDiedAction OnEnemyDied;

    [SerializeField] Weapon weapon;
    Transform target;
    Weapon currentWeapon;

    void Start()
    {
        currentWeapon = Instantiate(weapon);
        currentWeapon.Pickup();
        objectInHand = currentWeapon;
        AttachObjectToHand(currentWeapon.transform);
        target = FindObjectOfType<Player>().transform;
    }

    void Update()
    {
        if (currentWeapon && target)
        {
            Vector3 dir = target.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            currentWeapon.Shoot();
        }
    }

    protected override void Death()
    {
        DropObject();
        if (OnEnemyDied != null)
            OnEnemyDied();
        base.Death();
    }
}
