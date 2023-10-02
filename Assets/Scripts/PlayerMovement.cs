using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private float horizontalInput, verticalInput;

    private enum MovementState
    {
        idle,
        running
    }

    private void Start()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        ReadInput();
        MovePlayer();
        UpdateAnimation();
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

    private void UpdateAnimation()
    {
        MovementState state;

        if (horizontalInput > 0f || verticalInput > 0f)
        {
            state = MovementState.running;
            SetDirection("X", false);
        }
        else if (horizontalInput < 0f || verticalInput < 0f)
        {
            state = MovementState.running;
            SetDirection("X", true);
        }
        else
        {
            state = MovementState.idle;
        }

        animator.SetInteger("state", ((int)state));
    }

    private void SetDirection(string directionText, bool state)
    {
        if (directionText == "X")
        {
            spriteRenderer.flipX = state;
        }
        if (directionText == "Y")
        {
            spriteRenderer.flipY = state;
        }
    }
}
