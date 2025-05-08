using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    private Rigidbody2D rb;
    private bool isFacingLeft = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y); // ������
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(isFacingLeft ? -moveSpeed : moveSpeed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ground��ǂɉ�����Ԃ������甽�]
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (Mathf.Abs(contact.normal.x) > 0.5f)
            {
                FlipDirection();
                break;
            }
        }

        // �v���C���[�ƏՓˎ��̏���
        if (collision.collider.CompareTag("Player"))
        {
            PlayerController player = collision.collider.GetComponent<PlayerController>();

            if (player != null)
            {
                Vector2 contactNormal = collision.contacts[0].normal;

                if (contactNormal.y < -0.5f)
                {
                    // �ォ�瓥��
                    Destroy(gameObject);
                }
                else
                {
                    // �� or ������Ԃ�����
                    player.TakeDamage();
                }
            }
        }
    }

    private void FlipDirection()
    {
        isFacingLeft = !isFacingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1; // �X�v���C�g���]
        transform.localScale = scale;
    }
}
