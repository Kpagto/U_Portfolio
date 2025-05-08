using System.Collections;
using UnityEngine;

public class PipeEnter : MonoBehaviour
{
    public Transform destination; // ���[�v��
    public float enterDelay = 0.5f; // ���[�v�܂ł̑ҋ@����

    public Vector3 fixedCameraPosition; // ���ʂł̌Œ�J�����ʒu

    private bool playerInPosition = false;
    private GameObject player;

    void Update()
    {
        if (playerInPosition && Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(WarpPlayer());
        }
    }

    private IEnumerator WarpPlayer()
    {
        // �v���C���[�̓������~�߂�
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<PlayerController>().enabled = false;

        yield return new WaitForSeconds(enterDelay);

        Camera.main.GetComponent<CameraFollow>().followEnabled = false;



        player.transform.position = destination.position;
        Camera.main.transform.position = fixedCameraPosition;
        // �������ĊJ
        player.GetComponent<PlayerController>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInPosition = true;
            player = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInPosition = false;
            player = null;
        }
    }
}
