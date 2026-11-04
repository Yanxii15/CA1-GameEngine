using UnityEngine;

public class Puzzles : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    //dEactivated
    [SerializeField] private Sprite ButtonD;
    //Activated
    [SerializeField] private Sprite ButtonA;
    [SerializeField] private GameObject BridgePrefab;
    [SerializeField] private Rigidbody2D BoxRb;
    private Vector3 initialPosition;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialPosition = BoxRb.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {   
            spriteRenderer.sprite = ButtonA;
            BridgePrefab.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {   
            spriteRenderer.sprite = ButtonD;
            BridgePrefab.SetActive(false);
        }
    }

    public void ResetPuzzle()
    {
        BoxRb.transform.position = initialPosition;
    }
}
