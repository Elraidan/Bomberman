using UnityEngine;

public class AnimatedSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite idleSprite;
    public Sprite[] animationSprites;
    public float animationTime = 0.25f;
    private int animationFrame;
    private int totalFrames;

    public bool loop = true;
    public bool idle = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        totalFrames = animationSprites.Length;
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
        InvokeRepeating(nameof(NextFrame), animationTime, animationTime);
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
        CancelInvoke(nameof(NextFrame));
    }

    private void NextFrame()
    {
        if (idle)
        {
            spriteRenderer.sprite = idleSprite;
        }
        else
        {
            animationFrame++;

            if (animationFrame < totalFrames)
            {
                spriteRenderer.sprite = animationSprites[animationFrame];
            }
            else if (loop)
            {
                animationFrame = 0;
            }
            else
            {
                // Optionally, stop the animation if not looping.
                CancelInvoke(nameof(NextFrame));
            }
        }
    }
}
