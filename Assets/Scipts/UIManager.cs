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
    }

    public void StartGame()
    {
        menu.SetActive(false);
        playerMovement.enabled = true;
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
        playerMovement.enabled = false;
        GOMenu.SetActive(true);
    }

    public void ShowGameWon()
    {
        playerMovement.enabled = false;
        WinMenu.SetActive(true);
    }

    public void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateCoinCount(int coinCount)
    {
        coinCountText.text = "Coins: " + coinCount.ToString();
    }

}
