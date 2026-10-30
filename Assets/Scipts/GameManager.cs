using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    [Header("Lighting")]
    [SerializeField] private Light2D playerLight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateLighting(float amount)
    {   
        //will be controlled based on player "Lives", o represent ease when they die alot
        if (playerLight != null)
        {
            playerLight.pointLightOuterRadius = amount;
        }
    }

}
