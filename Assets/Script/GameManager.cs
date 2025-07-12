// ============================
// GameManager.cs
// ============================
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject countdownPanel;
    public GameObject gameUI;
    public GameObject gameOverPanel;

    [Header("Countdown Text")]
    public TextMeshProUGUI countdownText;

    [Header("Gameplay UI")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highestScoreText;

    [Header("Game Over UI")]
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI gameOverHighestScoreText;
    public GameObject tapToContinueText;

    [Header("Settings")]
    public float gameDuration = 120f; // Total game time in seconds

    private float gameTimer;
    private int score = 0;
    private int highestScore = 0;
    private bool isGameRunning = false;
    private bool isCountingDown = false;
    private bool isGameOver = false;

    void Start()
    {
        countdownPanel.SetActive(false);
        gameUI.SetActive(false);
        gameOverPanel.SetActive(false);
        tapToContinueText.SetActive(false);
        Time.timeScale = 1f;

        gameTimer = gameDuration;
        highestScore = PlayerPrefs.GetInt("HighestScore", 0);
        highestScoreText.text = "Highest Score: " + highestScore;

        StartCoroutine(StartCountdown());
    }

    void Update()
    {
        if (isGameRunning)
        {
            gameTimer -= Time.deltaTime;
            timerText.text = FormatTime(gameTimer);

            if (gameTimer <= 0)
            {
                EndGame();
            }
        }
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("UIandAudio");
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

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();

        // Update Highest Score in real-time
        if (score > highestScore)
        {
            highestScore = score;
            highestScoreText.text = "Highest Score: " + highestScore;
            PlayerPrefs.SetInt("HighestScore", highestScore);
            PlayerPrefs.Save();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void EndGame()
    {
        isGameRunning = false;
        isGameOver = true;

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

        // Display current highest score
        gameOverHighestScoreText.text = "Highest Score: " + highestScore;

        // If new record, animate it
        if (score > PlayerPrefs.GetInt("HighestScore", 0))
        {
            gameOverHighestScoreText.transform.localScale = Vector3.one * 2.5f;
            yield return ScaleDown(gameOverHighestScoreText.transform);
        }

        yield return new WaitForSecondsRealtime(0.5f);
        tapToContinueText.SetActive(true);
        Time.timeScale = 0f;
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Add200ScoreByButton()
    {
        AddScore(200);
    }
}