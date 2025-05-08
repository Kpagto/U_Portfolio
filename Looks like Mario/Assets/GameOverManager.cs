using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public float fallThresholdY = -10f;
    public float restartDelay = 5f;

    void Update()
    {
        if (GameObject.FindWithTag("Player").transform.position.y < fallThresholdY)
        {
            Invoke("RestartLevel", restartDelay);
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
