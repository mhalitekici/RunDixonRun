using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startText;
    public GameObject gameOverText;
    public GameObject finishedText;

    [HideInInspector] public bool isGameStarted = false;
    [HideInInspector] public bool isGameOver = false;

    void Start()
    {
        // Oyun başında durur
        Time.timeScale = 0f;

        // UI ayarları
        if (startText != null) startText.SetActive(true);
        if (gameOverText != null) gameOverText.SetActive(false);
        if (finishedText != null) finishedText.SetActive(false);
    }

    void Update()
    {
        // Space'e basınca başlasın
        if (!isGameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        isGameStarted = true;
        Time.timeScale = 1f;
        if (startText != null) startText.SetActive(false);
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Time.timeScale = 0f;
            if (gameOverText != null) gameOverText.SetActive(true);
        }
    }

    public void Finished()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Time.timeScale = 0f;
            if (finishedText != null) finishedText.SetActive(true);
        }
    }
}
