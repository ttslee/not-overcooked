﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    public float fspeed;
    //Player
    public int player = 1;

    //Animation
    public Animator animator;
    float originalPos = 0;
    private float floatStrength = 0.002f;

    //Movement
    Vector2 movement;
    public float moveSpd = 1f;
    private string horizontal, vertical;
    public Rigidbody2D playerBody;

    //Item Pickup
    private GameObject it;
    private Transform item;
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

    private Timer timer;
    private void Start()
    {
        horizontal = (player == 1) ? "Horizontal" : "Horizontal2";
        vertical = (player == 1) ? "Vertical" : "Vertical2";
        timer = gameObject.GetComponent<Timer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            QuitGame();
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
            case 3:
                if (Input.GetKeyDown("t"))
                    Projectile();
                break;
            case 4:
                if (Input.GetKeyDown("enter"))
                    Projectile();
                break;
        }

    }

    void FixedUpdate()
    {
        playerBody.MovePosition(playerBody.position + movement * moveSpd * Time.fixedDeltaTime);
        if(timer.Done)
        {
            dropped = false;
        }
        if(IsHoldingItem)
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
        Item.parent = null;
        it.GetComponent<CircleCollider2D>().enabled = true;
        it.GetComponent<ItemPickup>().Drop(calcLocalPos());
        dropped = true;
        IsHoldingItem = false;
        it = null;
        Item = null;
        originalPos = 0;
        timerStart();
    }

    private void PickUp(Collider2D collision)
    {
        Item = collision.gameObject.transform;
        Item.parent = transform;
        if (movement.y == 0 && movement.x == 0)
        {
            Item.localPosition = new Vector3(0, -.3f, 1f);
        }
        else
            setItemPosition();
    }

    private void setItemPosition()
    {

        if (movement.y >= .1f && movement.x == 0 && originalPos != .3f)
        {
            Item.localPosition = new Vector3(0, .3f, 1f);
            originalPos = .3f;
        }
        else if (movement.y <= -.1 && movement.x == 0 && originalPos != -.3f)
        {
            Item.localPosition = new Vector3(0, -.3f, 1f);
            originalPos = -.3f;
        }
        else if ((movement.x <= -.1 || movement.x >= .1f) && originalPos != 0.1f)
        {
            Item.localPosition = new Vector3(.4f, 0, 1f);
            originalPos = 0.4f;
        }
        

        Item.transform.position = new Vector3(Item.position.x,
        Item.position.y + ((float)Mathf.Sin(Time.time) * floatStrength), 1f);
        
    }

    private void Projectile()
    {
        Vector2 Direction = new Vector2(1, 0);
        Direction = Direction.normalized * fspeed;
        GameObject newProjectile = (GameObject) Instantiate(projectile, transform.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody2D>().velocity = Direction;
        Destroy(newProjectile, 5);
    }

    private void timerStart()
    {
        timer.SetTime(.4f, "Player");
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
    public void QuitGame()
    {
        // save any game data here
        #if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
        #else
         Application.Quit();
        #endif
    }
}
