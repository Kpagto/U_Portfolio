using UnityEngine;

public class MushroomEffect : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Grow();
            }

            Destroy(gameObject); // ‚«‚Ì‚±‚ğÁ‚·
        }
    }
}
