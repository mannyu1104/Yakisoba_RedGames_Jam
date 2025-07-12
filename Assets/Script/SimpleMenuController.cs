using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimpleMenuController : MonoBehaviour
{
    [Header("UI References")]
    public GameObject menuPanel;
    public GameObject howToPlayPanel;
    public GameObject leaderboardPanel;
    public Button howToPlayButton;
    public Button closeHowToPlayButton;
    public Button tapToStartButton;
    public Button leaderboardButton;
    public Button closeLeaderboardButton;

    [Header("Scene Settings")]
    public string gameSceneName = "GameScene";

    private bool isShowingHowToPlay = false;

    void Start()
    {
        howToPlayPanel.SetActive(false);
        leaderboardPanel.SetActive(false);

        howToPlayButton.onClick.AddListener(ShowHowToPlay);
        closeHowToPlayButton.onClick.AddListener(HideHowToPlay);
        leaderboardButton.onClick.AddListener(ShowLeaderboard);
        closeLeaderboardButton.onClick.AddListener(HideLeaderboard);
        tapToStartButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void ShowHowToPlay()
    {
        isShowingHowToPlay = true;
        howToPlayPanel.SetActive(true);
        tapToStartButton.gameObject.SetActive(false);
    }

    public void HideHowToPlay()
    {
        isShowingHowToPlay = false;
        howToPlayPanel.SetActive(false);
        tapToStartButton.gameObject.SetActive(true);
    }

    public void ShowLeaderboard()
    {
        leaderboardPanel.SetActive(true);
        tapToStartButton.gameObject.SetActive(false);
    }

    public void HideLeaderboard()
    {
        leaderboardPanel.SetActive(false);
        tapToStartButton.gameObject.SetActive(true);
    }
}
