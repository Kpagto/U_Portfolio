using UnityEngine;

public class BrickBlock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            // 衝突した位置と法線を確認
            foreach (ContactPoint2D contact in collision.contacts)
            {
                // 下から上への衝突のみ
                if (contact.normal.y > 0.5f)
                {
                    if (player != null && player.isBig)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        Debug.Log("小さい状態なのでブロックは壊れない");
                    }
                    break;
                }
            }
        }
    }

}
