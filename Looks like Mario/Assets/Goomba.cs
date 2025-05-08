using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    private Rigidbody2D rb;
    private bool isFacingLeft = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y); // 左向き
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(isFacingLeft ? -moveSpeed : moveSpeed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Groundや壁に横からぶつかったら反転
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (Mathf.Abs(contact.normal.x) > 0.5f)
            {
                FlipDirection();
                break;
            }
        }

        // プレイヤーと衝突時の処理
        if (collision.collider.CompareTag("Player"))
        {
            PlayerController player = collision.collider.GetComponent<PlayerController>();

            if (player != null)
            {
                Vector2 contactNormal = collision.contacts[0].normal;

                if (contactNormal.y < -0.5f)
                {
                    // 上から踏んだ
                    Destroy(gameObject);
                }
                else
                {
                    // 横 or 下からぶつかった
                    player.TakeDamage();
                }
            }
        }
    }

    private void FlipDirection()
    {
        isFacingLeft = !isFacingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1; // スプライト反転
        transform.localScale = scale;
    }
}
