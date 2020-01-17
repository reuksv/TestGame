using UnityEngine;

public abstract class PickableObject : MonoBehaviour
{
    public virtual void Pickup()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    public virtual void Drop()
    {
        GetComponent<Collider2D>().enabled = true;
    }
}
