using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player
    public int player = 1;

    //Movement/Animation
    public Animator animator;
    Vector2 movement;
    public float moveSpd = 1f;
    private string horizontal, vertical;
    public Rigidbody2D playerBody;

    //Item Pickup
    private GameObject it;
    private Transform item;
    private float timer = 2.0f;
    private bool dropped = false;

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
        if (movement.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        } else if (movement.x > 0)
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
        if(timer <= 0)
        {
            dropped = false;
            timer = 2.0f;
            print("reset");
        }
        if(dropped)
        {
            timer -= Time.fixedDeltaTime;
        }
        else if(IsHoldingItem)
            setItemPosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsHoldingItem && !dropped && collision.gameObject.CompareTag("Item") && collision.gameObject.GetComponent<ItemPickup>().Holder == 0)
        {
            IsHoldingItem = true;
            it = collision.gameObject;
            it.GetComponent<CircleCollider2D>().enabled = false;
            it.GetComponent<ItemPickup>().Holder = player;
            PickUp(collision);
        }
            
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!IsHoldingItem && !dropped && other.gameObject.CompareTag("Item") && other.gameObject.GetComponent<ItemPickup>().Holder == 0)
        {
            IsHoldingItem = true;
            it = other.gameObject;
            it.GetComponent<CircleCollider2D>().enabled = false;
            it.GetComponent<ItemPickup>().Holder = player;
            PickUp(other);
        }
    }
    private void Drop()
    {
        print("here");
        Item.parent = null;
        it.GetComponent<CircleCollider2D>().enabled = true;
        it.GetComponent<ItemPickup>().Drop(calcLocalPos());
        IsHoldingItem = false;
        it = null;
        Item = null;

        timerStart();
    }

    private void PickUp(Collider2D collision)
    {
        Item = collision.gameObject.transform;
        if (Item == null)
            return;
        Item.parent = transform;
        if(movement.y == 0 && movement.x == 0)
            Item.localPosition = new Vector3(0, -.4f, 1f);
        else
            setItemPosition();
    }

    private void setItemPosition()
    {
        
        if (movement.y >= .1f)
        {
            Item.localPosition = new Vector3(0, .4f, 1f);
        }
        else if (movement.y <= -.1)
        {
            Item.localPosition = new Vector3(0, -.4f, 1f);
        }
        else if (movement.x <= -.1 || movement.x >= .1f)
        {
            Item.localPosition = new Vector3(.4f, 0, 1f);
        }
    }

    private void timerStart()
    {
        dropped = true;
    }

    private string calcLocalPos()
    {
        Vector3 localPos = Item.localPosition - transform.position;

        if (localPos.x < 0)
            return "left";
        else if (localPos.x > 0)
            return "right";
        else if (localPos.y < 0)
            return "down";
        else if (localPos.y > 0)
            return "up";
        else
            return "none";
    }
}
