using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Button startButton;
    [SerializeField] private Image[] hearts;
    [SerializeField] private GameObject menu;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Sprite heartFull;
    [SerializeField] private Sprite heartEmpty;

    void Start()
    {
        menu.SetActive(true);
    }

    public void StartGame()
    {
        menu.SetActive(false);
        playerMovement.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHearts(int currentLives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentLives)
            {
                hearts[i].sprite = heartFull;
            }
            else
            {
                hearts[i].sprite = heartEmpty;
            }
        }
    }

}
