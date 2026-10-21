using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{   
    private Vector2 spawnPoint;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
     [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 5.0f; //tiles
    [SerializeField] private float jumpHeight = 2.5f; //tiles
    //[SerializeField] private bool isForwards = true;
    bool isOnGround = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = InputSystem.actions["Move"].ReadValue<Vector2>();
        if (moveDirection.x > 0)
        {
            isForwards = true;
        }
        else if (moveDirection.x < 0)
        {
            isForwards = false;
        }
        if (InputSystem.actions["Jump"].triggered && isOnGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Sqrt(jumpHeight * -2f * Physics2D.gravity.y));
            isOnGround = false;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * walkSpeed, rb.linearVelocity.y);
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
        // Physcias. the Normal is the force opposite to what any X object is "standing" on.
        // Getting its slope/y value can let me knwo if my player is touchign a wall or he flat groudn or a slope and react accordingly
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isOnGround = false;
    }

}
