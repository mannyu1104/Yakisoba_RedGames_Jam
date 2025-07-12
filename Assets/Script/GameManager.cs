using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject howToPlayPanel;
    public GameObject countdownPanel;
    public GameObject gameUI;
    public GameObject gameOverPanel;

    [Header("Countdown Text")]
    public TextMeshProUGUI countdownText;

    [Header("Gameplay UI")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    [Header("Game Over UI")]
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI gameOverHighScoreText;
    public GameObject tapToContinueText;

    [Header("Settings")]
    public float gameDuration = 120f; // 2 minutes

    private float gameTimer;
    private int score = 0;
    private int highScore = 0;
    private bool isGameRunning = false;
    private bool isCountingDown = false;
    private bool isGameOver = false;

    void Start()
    {
        howToPlayPanel.SetActive(true);
        countdownPanel.SetActive(false);
        gameUI.SetActive(false);
        gameOverPanel.SetActive(false);
        tapToContinueText.SetActive(false);
        Time.timeScale = 1f;

        gameTimer = gameDuration;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
    }

    void Update()
    {
        if (!isGameRunning && !isCountingDown && !isGameOver && Input.GetMouseButtonDown(0) && howToPlayPanel.activeSelf)
        {
            howToPlayPanel.SetActive(false);
            StartCoroutine(StartCountdown());
        }

        if (isGameRunning)
        {
            gameTimer -= Time.deltaTime;
            timerText.text = FormatTime(gameTimer);

            if (Input.GetKeyDown(KeyCode.A))
            {
                AddScore(200);
            }

            if (gameTimer <= 0)
            {
                EndGame();
            }
        }

        if (isGameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("UIandAudio");
        }
    }

    IEnumerator StartCountdown()
    {
        isCountingDown = true;
        countdownPanel.SetActive(true);
        gameUI.SetActive(false);

        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            countdownText.transform.localScale = Vector3.one * 3f;
            yield return ScaleDown(countdownText.transform);
        }

        countdownText.text = "Start!";
        countdownText.transform.localScale = Vector3.one * 3f;
        yield return ScaleDown(countdownText.transform);

        countdownPanel.SetActive(false);
        StartGame();
    }

    IEnumerator ScaleDown(Transform target)
    {
        float duration = 0.5f;
        Vector3 startScale = target.localScale;
        Vector3 endScale = Vector3.one;
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            target.localScale = Vector3.Lerp(startScale, endScale, t / duration);
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
    }

    void StartGame()
    {
        isCountingDown = false;
        isGameRunning = true;
        gameUI.SetActive(true);
        score = 0;
        gameTimer = gameDuration;
        UpdateScoreText();
    }

    void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void EndGame()
    {
        isGameRunning = false;
        isGameOver = true;
        Time.timeScale = 0f;

        gameOverPanel.SetActive(true);
        StartCoroutine(AnimateFinalScore());
    }

    IEnumerator AnimateFinalScore()
    {
        int displayScore = 0;
        finalScoreText.text = "Final Score: 0";

        int step = Mathf.Max(1, score / 100);
        while (displayScore < score)
        {
            displayScore += step;
            if (displayScore > score) displayScore = score;
            finalScoreText.text = "Final Score: " + displayScore;
            yield return new WaitForSecondsRealtime(0.01f);
        }

        // High score logic
        if (score >= highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
            gameOverHighScoreText.text = "High Score: " + score;
            gameOverHighScoreText.transform.localScale = Vector3.one * 2.5f;
            yield return ScaleDown(gameOverHighScoreText.transform);
        }
        else
        {
            gameOverHighScoreText.text = "High Score: " + highScore;
        }

        yield return new WaitForSecondsRealtime(0.5f);
        tapToContinueText.SetActive(true);
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
