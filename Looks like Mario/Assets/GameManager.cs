using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameClearText;

    private int coinCount = 0;
    public TextMeshProUGUI coinText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        ResetCoins();
    }

    public void GameClear()
    {
        if (gameClearText != null)
        {
            gameClearText.SetActive(true);
        }

        StartCoroutine(RestartAfterDelay());
    }

    public void AddCoin()
    {
        coinCount++;
        UpdateCoinUI();
    }

    public void ResetCoins()
    {
        coinCount = 0;
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = "coin Å~ " + coinCount;
        }
    }

    private System.Collections.IEnumerator RestartAfterDelay()
    {
        yield return new WaitForSeconds(2.5f);

        if (gameClearText != null)
        {
            gameClearText.SetActive(false);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
