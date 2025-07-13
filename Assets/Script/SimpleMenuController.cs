using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SimpleMenuController : MonoBehaviour
{
    [Header("UI References")]
    public GameObject menuPanel;
    public GameObject howToPlayPanel;
    public GameObject leaderboardPanel;
    public GameObject changeControlPanel; // ← 加上这一行
    public Button howToPlayButton;
    public Button closeHowToPlayButton;
    public Button tapToStartButton;
    public Button leaderboardButton;
    public Button closeLeaderboardButton;
    public Button changeControlButton;

    public Button closeChangeControlButton;

    public TextMeshProUGUI highestScoreText;

    [Header("Scene Settings")]
    public string gameSceneName = "GameScene";

    void Start()
    {
        howToPlayPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
        changeControlPanel.SetActive(false);

        howToPlayButton.onClick.AddListener(ShowHowToPlay);
        closeHowToPlayButton.onClick.AddListener(HideHowToPlay);
        leaderboardButton.onClick.AddListener(ShowLeaderboard);
        closeLeaderboardButton.onClick.AddListener(HideLeaderboard);
        changeControlButton.onClick.AddListener(ShowChangeControlOptions);
        closeChangeControlButton.onClick.AddListener(HideChangeControlOptions);

        tapToStartButton.onClick.AddListener(StartGame);


        int highestScore = PlayerPrefs.GetInt("HighestScore", 0);
        highestScoreText.text = "Highest Score: " + highestScore;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void ShowHowToPlay()
    {
        howToPlayPanel.SetActive(true);
        tapToStartButton.gameObject.SetActive(false);
    }

    public void HideHowToPlay()
    {
        howToPlayPanel.SetActive(false);
        tapToStartButton.gameObject.SetActive(true);
    }

    public void ShowLeaderboard()
    {
        leaderboardPanel.SetActive(true);
    }

    public void HideLeaderboard()
    {
        leaderboardPanel.SetActive(false);
    }

    public void ShowChangeControlOptions()
    {
        changeControlPanel.SetActive(true);
        tapToStartButton.gameObject.SetActive(false);
    }
    public void HideChangeControlOptions()
    {
        changeControlPanel.SetActive(false);
        tapToStartButton.gameObject.SetActive(true);
    }

}