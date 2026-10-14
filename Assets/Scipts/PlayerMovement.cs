using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    private Rigidbody2D rb;
    float walkSpeed = 5.0f; //tiles per second
    float jumpHeight = 2.0f; //tiles
    bool isOnGround = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
