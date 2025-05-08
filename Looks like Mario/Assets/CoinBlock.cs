using UnityEngine;

public class CoinBlock : MonoBehaviour
{
    public Sprite usedSprite; // ’@‚©‚ê‚½Œã‚ÌŒ©‚½–Ú

    private bool isUsed = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isUsed) return;

        if (collision.collider.CompareTag("Player"))
        {
            // Õ“Ë“_‚ª‰º‚©‚ç‚©”»’è
            if (collision.contacts[0].normal.y > 0.5f)
            {
                isUsed = true;
                GameManager.Instance.AddCoin();

                // Œ©‚½–Ú•ÏX
                if (usedSprite != null)
                    spriteRenderer.sprite = usedSprite;
            }
        }
    }
}
