using UnityEngine;

public class ShadePatrol : MonoBehaviour
{

    [Header("Patrol Settings")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float patrolSpeed = 2.0f;
    [SerializeField] private float leftBoundary = 24.5f;
    [SerializeField] private float rightBoundary = 33.5f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(patrolSpeed, rb.linearVelocity.y);

        if (transform.position.x >= rightBoundary)
        {
            patrolSpeed = -Mathf.Abs(patrolSpeed);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (transform.position.x <= leftBoundary)
        {
            patrolSpeed = Mathf.Abs(patrolSpeed);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }


}
