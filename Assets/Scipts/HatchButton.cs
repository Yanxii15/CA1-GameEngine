using UnityEngine;

public class HatchButton : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [Header("References/Objects")]
    [SerializeField] private PlatformEffector2D hatchPlatformEffector;
    [SerializeField] private SpriteRenderer hatchSpriteRenderer;
    [SerializeField] private Sprite hatchOpenSprite;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Sprite pressedButtonSprite;
    private bool isButtonPressed = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isButtonPressed)
        {
            isButtonPressed = true;
            spriteRenderer.sprite = pressedButtonSprite;
            hatchSpriteRenderer.sprite = hatchOpenSprite;
            hatchPlatformEffector.useOneWay = true;
            audioSource.Play();
        }
    }

}
