using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    public Sprite usedBlockSprite;
    public GameObject mushroomPrefab;
    public Transform spawnPoint;

    private bool isUsed = false;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isUsed) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            // ヒット方向確認
            if (collision.contacts[0].normal.y > 0.5f)
            {
                isUsed = true;
                sr.sprite = usedBlockSprite;

                // きのこ生成
                if (mushroomPrefab != null && spawnPoint != null)
                {
                    Instantiate(mushroomPrefab, spawnPoint.position, Quaternion.identity);
                }
            }
        }
    }
}
