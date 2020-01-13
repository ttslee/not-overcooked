using UnityEngine;

public class PlayerController2 : MonoBehaviour
{

    //Movement
    [SerializeField]
    private float moveSpd = 1f;
    [SerializeField]
    private Rigidbody2D playerBody;


    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal2");
        movement.y = Input.GetAxisRaw("Vertical2");
        if (movement.x == -1)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (movement.x == 1)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void FixedUpdate()
    {
        playerBody.MovePosition(playerBody.position + movement * moveSpd * Time.fixedDeltaTime);
    }

}
