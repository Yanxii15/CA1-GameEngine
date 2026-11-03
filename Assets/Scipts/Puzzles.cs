using UnityEngine;

public class Puzzles : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Sprite ButtonD;
    [SerializeField] private GameObject BridgePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boxr"))
        {   
            //Player has touched the button
            BridgePrefab.SetActive(true);
        }else{
            BridgePrefab.SetActive(false);
        }
    }

    public void ResetPuzzle()
    {
        BridgePrefab.position = new Vector3(15, 6, 0);
    }
}
