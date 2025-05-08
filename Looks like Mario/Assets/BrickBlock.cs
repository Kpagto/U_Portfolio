using UnityEngine;

public class BrickBlock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            // �Փ˂����ʒu�Ɩ@�����m�F
            foreach (ContactPoint2D contact in collision.contacts)
            {
                // �������ւ̏Փ˂̂�
                if (contact.normal.y > 0.5f)
                {
                    if (player != null && player.isBig)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        Debug.Log("��������ԂȂ̂Ńu���b�N�͉��Ȃ�");
                    }
                    break;
                }
            }
        }
    }

}
