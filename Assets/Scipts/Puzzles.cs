using UnityEngine;

public class Puzzles : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    //dEactivated
    [SerializeField] private Sprite ButtonD;
    //Activated
    [SerializeField] private Sprite ButtonA;
    [SerializeField] private GameObject BridgePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        BridgePrefab.transform.position = new Vector3(15, 6, 0);
    }
}
