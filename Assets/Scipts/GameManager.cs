using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Puzzles puzzles;
    private int CoinCount = 0;

    [Header("Stages/Scenes")]
    [SerializeField] private string nextSceneName = "Stage2";


    [Header("Lighting")]
    //I likd thel ook of out 1.5 wiht in 0.35 therefore ue rtio akin to tha
    [SerializeField] private Light2D mapLight;
    [SerializeField] private Light2D playerLight;
    [SerializeField] private float maxLightRadius = 4.0f;
    [SerializeField] private float minLightRadius = 1.5f;
    [SerializeField] private float middleLightRadius = 2.75f;
    // all these ore outer radius max
    [SerializeField] private float ratio = 0.24f;
    [SerializeField] private int ShardsHeld = 0;

    [Header("Lives")]
    [SerializeField] private int playerMaxLives = 3;
    [SerializeField] private int playerCurrentLives = 0;

    [Header("Respawn")]
    [SerializeField] private Transform playerRespawnPoint;
    [SerializeField] private Rigidbody2D PlayerRb;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip coinCollectSound;
    [SerializeField] private AudioClip playerDeathSound;
    [SerializeField] private AudioClip playerWinSound;

    void Start()
    {
        mapLight.intensity = 0.1f;
        mapLight.color = new Color(0.45f, 0.43f, 0.43f);
        playerCurrentLives = playerMaxLives;
        UpdateLighting(playerCurrentLives);
        uiManager.UpdateHearts(playerCurrentLives);
        uiManager.UpdateCoinCount(CoinCount);
    }

    public void PlayerDied()
    {
        playSound(playerDeathSound);
        playerCurrentLives--;
        uiManager.UpdateHearts(playerCurrentLives);
        if (playerCurrentLives <= 0)
        {
            PlayerLost();
            Debug.Log("Game Over!");
        }
        else
        {
            RespawnPlayer();
            UpdateLighting(playerCurrentLives);
        }
    }

    public void RespawnPlayer()
    {
        // Move the player to the respawn point
        if (PlayerRb != null && playerRespawnPoint != null)
        {
            PlayerRb.position = playerRespawnPoint.position;
            // Reset player's velocity to zero
            PlayerRb.linearVelocity = Vector2.zero;
            if (puzzles != null)
            {
                puzzles.ResetPuzzle();
            }  
        }
    }

    void UpdateLighting(int lives)
    {   
        if (playerLight != null)
        {
            if (lives == 3)
            {
                playerLight.pointLightOuterRadius = minLightRadius;
            }
            else if (lives == 2)
            {
                playerLight.pointLightOuterRadius = middleLightRadius;
            }
            else if (lives == 1)
            {
                playerLight.pointLightOuterRadius = maxLightRadius;
            }
            InnerLight(playerLight.pointLightOuterRadius);
        }
        
    }

    void InnerLight(float currentOuter)
    {
        if (playerLight != null)
        {
            playerLight.pointLightInnerRadius = currentOuter * ratio;
        }
    }

    public void PlayerWon()
    {
        playSound(playerWinSound);
        Debug.Log("Player has won the game!");
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            uiManager.ShowGameWon();
        }
    }

    public void PlayerLost()
    {
        Debug.Log("Player has lost the game!");
        uiManager.ShowGameOver();
    }

    public void CollectCoin(GameObject coin)
    {
        playSound(coinCollectSound);
        Destroy(coin);
        CoinCount++;
        uiManager.UpdateCoinCount(CoinCount);
    }

    private void playSound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void CollectShard(GameObject shard)
    {
        playSound(coinCollectSound);
        //Need to make a ew sound
        Destroy(shard);
        ShardsHeld++;
        UpdateLighting(playerCurrentLives - ShardsHeld);
    }

}
