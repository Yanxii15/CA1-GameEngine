using UnityEngine;

public class HatchButton : MonoBehaviour
{
    [Header("References/Objects")]
    [SerializeField] private PlatformEffector2D hatchPlatformEffector;
    [SerializeField] private SpriteRenderer hatchSpriteRenderer;
    [SerializeField] private Sprite hatchOpenSprite;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Sprite pressedButtonSprite;
    [SerializeField] private Sprite unpressedButtonSprite;
    [SerializeField] private bool isButtonPressed = false;
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
