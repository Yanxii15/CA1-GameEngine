using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    [Header("Lighting")]
    //I likd thel ook of out 1.5 wiht in 0.35 therefore ue rtio akin to tha
    [SerializeField] private Light2D playerLight;
    [SerializeField] private float maxLightRadius = 4.0f;
    [SerializeField] private float minLightRadius = 1.5f;
    [SerializeField] private float middleLightRadius = 2.75f;
    // all these ore outer radius max
    [SerializeField] private float ratio = 0.24f;

    [Header("Lives")]
    [SerializeField] private int playerMaxLives = 3;
    [SerializeField] private int playerCurrentLives = 0;

    [Header("Respawn")]
    [SerializeField] private Transform playerRespawnPoint;
    [SerializeField] private Rigidbody2D PlayerRb;

    void Start()
    {
        playerCurrentLives = playerMaxLives;
        UpdateLighting(minLightRadius);
        //Need o add Respawn point in here somehow. either get the players position when htey sart he game or a new object with a tag
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDied()
    {
        playerCurrentLives--;
        if (playerCurrentLives <= 0)
        {
            Debug.Log("Game Over!");
        }
        else
        {
            RespawnPlayer();
            UpdateLighting(playerLight.pointLightOuterRadius);
            InnerLight(playerLight.pointLightOuterRadius);
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
        }
    }

    void UpdateLighting(float amount)
    {   
        //will be controlled based on player "Lives", tto represent ease when they die alot
        if (playerLight != null)
        {
            playerLight.pointLightOuterRadius = amount;
        }
    }

    void InnerLight(float currentOuter)
    {
        if (playerLight != null)
        {
            playerLight.pointLightInnerRadius = currentOuter / ratio;
        }
    }

}
