using UnityEngine;

public class ShadePatrol : MonoBehaviour
{

    [Header("Patrol Settings")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float patrolSpeed = 2.0f;
    [SerializeField] private float targetX = 0.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Move the shade towards the target position
        Vector2 targetPosition = new Vector2(targetX, rb.position.y);
        rb.position = Vector2.MoveTowards(rb.position, targetPosition, patrolSpeed * Time.fixedDeltaTime);

        // Check if the shade has reached the target position
        if (Mathf.Approximately(rb.position.x, targetX))
        {
            // Reverse the direction of movement
            patrolSpeed = -patrolSpeed;
            // Update the target position to the opposite side
            targetX = -targetX;
        }
    }


}
