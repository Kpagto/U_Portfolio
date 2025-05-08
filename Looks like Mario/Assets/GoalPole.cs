using UnityEngine;


public class GoalPole : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().canMove = false;
            GameManager.Instance.GameClear();
        }
    }
}
