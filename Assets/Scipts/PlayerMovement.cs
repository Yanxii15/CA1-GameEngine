using UnityEngine;

using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{   
    [SerializeField] private GameManager gameManager;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Vector2 moveDirection;
    float currentSpeed;
    private Rigidbody2D rb;
    float YVelocity;

    [Header("Movement Settings")]
    [SerializeField] private float MaxwalkSpeed = 5.0f;
    [SerializeField] private float jumpHeight = 2.5f;
    [SerializeField] private bool isForwards = true;
    bool isOnGround = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveDirection = InputSystem.actions["Move"].ReadValue<Vector2>();

        // Only update facing direction if the player is actually pressing left or right
        if (moveDirection.x > 0.01f)
        {
            isForwards = true;
        }
        else if (moveDirection.x < -0.01f)
        {
            isForwards = false;
        }

        spriteRenderer.flipX = !isForwards;

        // Jump logic
        if (InputSystem.actions["Jump"].triggered && isOnGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Sqrt(jumpHeight * -2f * Physics2D.gravity.y));
            isOnGround = false;
            animator.SetBool("IsGrounded", false);
        }else
        {
            animator.SetBool("IsGrounded", isOnGround);
        }

        // Parameters for animator
        currentSpeed = Mathf.Abs(rb.linearVelocity.x);
        animator.SetFloat("Speed", currentSpeed);
        YVelocity = rb.linearVelocity.y;
        animator.SetFloat("YVelocity", YVelocity);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * MaxwalkSpeed, rb.linearVelocity.y);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.75f)
            {
                isOnGround = true;
                break;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isOnGround = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lava"))
        {
            gameManager.PlayerDied();
        }

        if (other.CompareTag("Exit"))
        {
            gameManager.PlayerWon();
        }

        if (other.CompareTag("Coin"))
        {
            gameManager.CollectCoin(other.gameObject);
        }
    }
}