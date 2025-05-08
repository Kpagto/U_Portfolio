using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear1up : MonoBehaviour
{
    public Sprite usedSprite; // �@���ꂽ��̌�����

    private bool isUsed = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isUsed) return;

        if (collision.collider.CompareTag("Player"))
        {
            // �Փ˓_�������炩
            if (collision.contacts[0].normal.y > 0.5f)
            {
                isUsed = true;
                for (int i = 0; i < 100; i++)
                {
                    GameManager.Instance.AddCoin();
                }
                // �����ڕύX
                if (usedSprite != null)
                    spriteRenderer.sprite = usedSprite;
            }
        }
    }
}
