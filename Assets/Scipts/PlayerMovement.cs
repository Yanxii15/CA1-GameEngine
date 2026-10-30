using UnityEngine;

using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{   
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Vector2 moveDirection;
    float currentSpeed;
    private Rigidbody2D rb;



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

        // Send the facing direction to the animator (RacingR)
        animator.SetBool("FacingR", isForwards);

        // Jump logic
        if (InputSystem.actions["Jump"].triggered && isOnGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Sqrt(jumpHeight * -2f * Physics2D.gravity.y));
            isOnGround = false;
        }

        // Speed parameter for animator
        currentSpeed = Mathf.Abs(rb.linearVelocity.x);
        animator.SetFloat("Speed", currentSpeed);
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



}