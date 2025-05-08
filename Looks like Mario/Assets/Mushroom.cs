using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D ‚ª‚ ‚è‚Ü‚¹‚ñI");
        }
        rb.velocity = new Vector2(moveSpeed, 0f);
    }

    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // •Ç‚É‚Ô‚Â‚©‚Á‚½‚ç•ûŒü“]Š·
        if (collision.contacts.Length > 0)
        {
            Vector2 normal = collision.contacts[0].normal;
            if (Mathf.Abs(normal.x) > 0.5f)
            {
                moveSpeed *= -1;
            }
        }

        if (collision.collider.CompareTag("Player"))
        {
            PlayerController player = collision.collider.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Grow();
            }

            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Grow();
            }

            Destroy(gameObject);
        }
    }
}
