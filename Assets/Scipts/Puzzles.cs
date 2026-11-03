using UnityEngine;

public class Puzzles : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite ButtonD;
    [SerializeField] private GameObject BridgePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = ButtonD;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {   
            //Player has touched the button
            BridgePrefab.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {   
            //Player has left the button
            BridgePrefab.SetActive(false);
        }
    }

    public void ResetPuzzle()
    {
        BridgePrefab.transform.position = new Vector3(15, 6, 0);
    }
}
