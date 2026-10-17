using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{   
    private Vector2 spawnPoint;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    float walkSpeed = 5.0f; //tiles per second
    float jumpHeight = 2.5f; //tiles
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
        if (InputSystem.actions["Jump"].triggered && isOnGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Sqrt(jumpHeight * -2f * Physics2D.gravity.y));
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * walkSpeed, rb.linearVelocity.y);
    }
}
