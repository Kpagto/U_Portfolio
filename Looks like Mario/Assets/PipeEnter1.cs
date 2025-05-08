using System.Collections;
using UnityEngine;

public class PipeEnter1 : MonoBehaviour
{
    public Transform destination; // ワープ先
    public float enterDelay = 0.5f; // ワープまでの待機時間

    private bool playerInPosition = false;
    private GameObject player;

    void Update()
    {
        if (playerInPosition && Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(WarpPlayer());
        }
    }

    private IEnumerator WarpPlayer()
    {
        // プレイヤーの動きを止める
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<PlayerController>().enabled = false;

        yield return new WaitForSeconds(enterDelay);

        player.transform.position = destination.position;

        Camera.main.GetComponent<CameraFollow>().followEnabled = true;

        // 動きを再開
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
