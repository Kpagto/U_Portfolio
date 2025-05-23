using UnityEngine;

public class CoinBlock : MonoBehaviour
{
    public Sprite usedSprite; // 叩かれた後の見た目

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
            // 衝突点が下からか判定
            if (collision.contacts[0].normal.y > 0.5f)
            {
                isUsed = true;
                GameManager.Instance.AddCoin();

                // 見た目変更
                if (usedSprite != null)
                    spriteRenderer.sprite = usedSprite;
            }
        }
    }
}
