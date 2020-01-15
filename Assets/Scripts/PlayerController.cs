using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player
    public int player = 1;

    //Movement/Animation/Pickup
    public Animator animator;
    Vector2 movement;

    [SerializeField]
    private float moveSpd = 1f;
    private string horizontal, vertical;

    [SerializeField]
    private Rigidbody2D playerBody;

    private Transform item;

    public Transform Item
    {
        get
        {
            return item;
        }

        set
        {
            item = value;
        }
    }

    private bool isHoldingItem = false;

    public bool IsHoldingItem
    {
        get
        {
            return isHoldingItem;
        }

        set
        {
            isHoldingItem = value;
        }
    }

    private void Start()
    {
        horizontal = (player == 1) ? "Horizontal" : "Horizontal2";
        vertical = (player == 1) ? "Vertical" : "Vertical2";
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw(horizontal);
        movement.y = Input.GetAxisRaw(vertical);
        movement = movement.normalized;

        animator.SetFloat("Speed", movement.sqrMagnitude);
        if (movement.x == -1)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        } else if (movement.x == 1)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        switch(player)
        {
            case 1:
                if (Input.GetKeyDown("e") && IsHoldingItem)
                    Drop();
                break;
            case 2:
                if (Input.GetKeyDown("right ctrl") && IsHoldingItem)
                    Drop();
                break;
        }


    }

    void FixedUpdate()
    {
        playerBody.MovePosition(playerBody.position + movement * moveSpd * Time.fixedDeltaTime);
        setItemPosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsHoldingItem && collision.gameObject.CompareTag("Item"))
            PickUp(collision);
    }

    private void Drop()
    {

    }

    private void PickUp(Collider2D collision)
    {
        Item = collision.gameObject.transform;
        Item.parent = transform;
        setItemPosition();
    }
    private void setItemPosition()
    {
        if (Item == null)
            return;
        if (movement.y == 1)
        {
            Item.localPosition = new Vector3(0, .7f, 1f);
        }
        else if (movement.y == -1)
        {
            Item.localPosition = new Vector3(0, -.4f, 1f);
        }
        else if (movement.x == -1)
        {
            Item.localPosition = new Vector3(-.7f, 0, 1f);
        }
        else if (movement.x == 1)
        {
            Item.localPosition = new Vector3(.4f, 0, 1f);
        }
    }
}
