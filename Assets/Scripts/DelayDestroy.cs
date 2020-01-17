using UnityEngine;

public class DelayDestroy : MonoBehaviour
{
    [SerializeField] float time;

    void Start()
    {
        Destroy(gameObject, time);
    }
}
