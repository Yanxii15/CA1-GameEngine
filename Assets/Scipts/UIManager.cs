using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Button startButton;
    //public Text scoreText;
    [SerializeField] private Image[] hearts;
    [SerializeField] private GameObject menu;
    [SerializeField] private PlayerMovement playerMovement;

    void Start()
    {
        menu.SetActive(true);
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
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

}
