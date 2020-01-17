using UnityEngine;

public class Player : Character
{
    public delegate void DiedAction();
    public static event DiedAction OnPlayerDied;

    [SerializeField] float speed;

    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement * speed);
    }

    void Update()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetButtonDown("Fire1") && objectInHand != null)
        {
            IUsable usableObject = objectInHand.GetComponent<IUsable>();
            if (usableObject != null)
                usableObject.Use();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            DropObject();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        IStationaryObjectUse usableObject = collision.GetComponent<IStationaryObjectUse>();
        if (usableObject != null && Input.GetKeyDown(KeyCode.F))
        {
            usableObject.Use();
        }

        PickableObject pickedObject = collision.GetComponent<PickableObject>();
        if (pickedObject != null && Input.GetKeyDown(KeyCode.F))
        {
            DropObject();
            pickedObject.Pickup();
            objectInHand = pickedObject;
            AttachObjectToHand(collision.transform);
        }
    }

    protected override void Death()
    {
        if (OnPlayerDied != null)
            OnPlayerDied();
        base.Death();
    }
}
