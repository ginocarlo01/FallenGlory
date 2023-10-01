using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    private Rigidbody2D rb;

    private float horizontalInput, verticalInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ReadInput();
        MovePlayer();
    }

    private void ReadInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void MovePlayer()
    {
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        movement.Normalize();

        rb.velocity = movement * speed;
    }
}
