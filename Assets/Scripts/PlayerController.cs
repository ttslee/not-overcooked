using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int player = 1;
    //Movement
    Vector2 movement;

    [SerializeField]
    private float moveSpd = 1f;

    private string horizontal, vertical;

    [SerializeField]
    private Rigidbody2D playerBody;

    private GameObject item;

    public GameObject Item
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
                if(Input.GetKeyDown("e") && IsHoldingItem)
                {
                    Drop();
                }
                break;
            case 2:
                if (Input.GetKeyDown("right ctrl") && IsHoldingItem)
                {
                    Drop();
                }
                break;
        }
    }

    void FixedUpdate()
    {
        playerBody.MovePosition(playerBody.position + movement * moveSpd * Time.fixedDeltaTime);
    }

    void Drop()
    {
    }

}
