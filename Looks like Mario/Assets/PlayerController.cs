using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;

    public bool canMove = true;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    private bool isGrounded;
    public bool isBig = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!canMove)
        {
            rb.velocity = new Vector2(0, rb.velocity.y); // ��~
            return;
        }
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(move));
        sr.flipX = move < 0;

        // �n�ʔ���
        isGrounded = Physics2D.OverlapCircle(transform.position + Vector3.down * 0.5f, 0.2f, groundLayer);
        animator.SetBool("IsJumping", !isGrounded);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (transform.position.y < -7f)
        {
            Vector3 pos = transform.position;
            pos.y = -7f;
            transform.position = pos;

            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
    }

    public void Grow()
    {
        if (!isBig)
        {
            StartCoroutine(GrowthSequence());
        }
    }

    private System.Collections.IEnumerator GrowthSequence()
    {
        canMove = false;

        rb.isKinematic = true; // �������Z�~�߂�

        int flashes = 0;
        while (flashes < 3)
        {
            isBig = !isBig;
            animator.SetBool("IsBig", isBig);
            yield return new WaitForSeconds(0.2f);
            flashes++;
        }

        isBig = true;
        animator.SetBool("IsBig", true);

        yield return new WaitForSeconds(0.3f);

        rb.isKinematic = false; // �ēx������悤�ɂ���
        canMove = true;
    }

    public void TakeDamage()
    {
        if (isBig)
        {
            isBig = false;
            animator.SetBool("IsBig", false);
            Debug.Log("���̂���Ԃ��������I");
        }
        else
        {
            // ���S���o
            StartCoroutine(DieAndRestart());
        }
    }

    public void Bounce()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce / 1.5f);
    }

    private IEnumerator DieAndRestart()
    {
        // �J������~
        Camera.main.GetComponent<CameraFollow>().enabled = false;
        canMove = false;

        // �A�j���[�V������~�W�����v�㏸�����Ă��痎��
        animator.enabled = false;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 8f);


        CapsuleCollider2D capsule = GetComponent<CapsuleCollider2D>();
        if (capsule != null)
        {
            capsule.enabled = false;
        }

        CameraFollow camFollow = Camera.main.GetComponent<CameraFollow>();
        if (camFollow != null)
        {
            camFollow.target = null;
        }



        rb.gravityScale = 5f; // �d�͂�傫�����ė���

        // �v���C���[�����~
        this.enabled = false;

        yield return new WaitForSeconds(2.5f);

        // �V�[�����X�^�[�g
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }



}
