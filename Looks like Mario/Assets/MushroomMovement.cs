using UnityEngine;

public class MushroomMovement : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D がアタッチされていません！");
        }
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 壁に当たったら方向を反転
        if (collision.contacts.Length > 0)
        {
            Vector2 normal = collision.contacts[0].normal;
            if (Mathf.Abs(normal.x) > 0.5f)
            {
                moveSpeed *= -1;
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
        }
    }
}
