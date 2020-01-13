using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Movement
    [SerializeField]
    private float moveSpd = 1f;
    [SerializeField]
    private Rigidbody2D playerBody;

    public int player = 1;

    private string horizontal, vertical;
    Vector2 movement;
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
    }

    void FixedUpdate()
    {
        playerBody.MovePosition(playerBody.position + movement * moveSpd * Time.fixedDeltaTime);
    }

}
