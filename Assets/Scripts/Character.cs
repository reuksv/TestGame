using UnityEngine;

public abstract class Character : MonoBehaviour, ITakeDamage
{
    [HideInInspector] public PickableObject objectInHand;

    [SerializeField] int health = 10;
    [SerializeField] Transform weaponAttachPoint;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Death();
    }

    protected virtual void AttachObjectToHand(Transform attachedObject)
    {
        attachedObject.parent = weaponAttachPoint;
        attachedObject.localPosition = Vector3.zero;
        attachedObject.localRotation = Quaternion.identity;
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }

    protected virtual void DropObject()
    {
        if (objectInHand)
        {
            objectInHand.Drop();
            objectInHand.transform.parent = null;
            objectInHand = null;
        }
    }
}
