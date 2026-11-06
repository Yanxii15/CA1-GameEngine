using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Image[] hearts;
    [SerializeField] private GameObject menu;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Sprite heartFull;
    [SerializeField] private Sprite heartEmpty;

    [Header("Menus")]
    [SerializeField] private GameObject GOMenu;
    [SerializeField] private GameObject WinMenu;

    [Header("Coin")]
    [SerializeField] private TextMeshProUGUI coinCountText;

    void Start()
    {
        menu.SetActive(true);
        Time.timeScale = 0f; // Pause the game at the start
    }

    public void StartGame()
    {
        menu.SetActive(false);
        playerMovement.enabled = true;
        Time.timeScale = 1f; // Resume the game
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

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        playerMovement.enabled = false;
        GOMenu.SetActive(true);
    }

    public void ShowGameWon()
    {
        Time.timeScale = 0f; 
        playerMovement.enabled = false;
        WinMenu.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateCoinCount(int coinCount)
    {
        coinCountText.text = "Coins: " + coinCount.ToString();
    }

    public void LoadSTage(string stageName)
    {
        SceneManager.LoadScene(stageName);
    }

}
