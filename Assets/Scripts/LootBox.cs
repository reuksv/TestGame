using UnityEngine;

public class LootBox : MonoBehaviour, IStationaryObjectUse, ITakeDamage
{
    [SerializeField] GameObject loot;

    int health = 5;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Open();
    }

    public void Use()
    {
        Open();
    }

    void Open()
    {
        if(loot)
            Instantiate(loot, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
