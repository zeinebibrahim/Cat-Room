using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    [SerializeField] private float flipThreshold = 0.1f;
    [SerializeField] private bool autoDetect = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (autoDetect && rb != null)
            SetDirection(rb.linearVelocity);
    }

    public void SetDirection(Vector2 moveDir)
    {
        if (moveDir.x > flipThreshold)
            spriteRenderer.flipX = false;
        else if (moveDir.x < -flipThreshold)
            spriteRenderer.flipX = true;
    }
}
