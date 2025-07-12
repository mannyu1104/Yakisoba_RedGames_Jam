using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// Controls a minimal menu with Tap-To-Start and HowToPlay panel.
/// </summary>
public class SimpleMenuController : MonoBehaviour
{
    [Header("UI References")]
    public GameObject menuPanel;           // Main menu UI (title + hint)
    public GameObject howToPlayPanel;      // Panel showing how to play
    public GameObject leaderboardPanel;    // Leaderboard panel
    public Button howToPlayButton;         // "How to Play" button
    public Button closeHowToPlayButton;    // "X" close button on top right
    public Button tapToStartButton; // Tap to start button
    public Button leaderboardButton; // Show Leaderboard
    public Button closeLeaderboardButton; // Close Leaderboard

    [Header("Scene Settings")]
    public string gameSceneName = "GameScene";

    private bool isShowingHowToPlay = false;
    private bool hasStarted = false;

    void Start()
    {
        howToPlayPanel.SetActive(false);
        leaderboardPanel.SetActive(false);

        // howToPlayButton.onClick.AddListener(ShowHowToPlay);
        // closeHowToPlayButton.onClick.AddListener(HideHowToPlay);
        // leaderboardButton.onClick.AddListener(ShowLeaderboard);
        // closeLeaderboardButton.onClick.AddListener(HideLeaderboard);
    }


    void Update()
    {
        if (hasStarted || isShowingHowToPlay)
            return;

        // if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        // {
        //     if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        //         return;
        //     StartGame();
        // }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            StartGame();
        }
    }

    /// <summary>
    /// Loads the main game scene.
    /// </summary>
    public void StartGame()
    {
        hasStarted = true;
        SceneManager.LoadScene(gameSceneName);
    }

    /// <summary>
    /// Shows the HowToPlay panel.
    /// </summary>
    public void ShowHowToPlay()
    {
        isShowingHowToPlay = true;
        howToPlayPanel.SetActive(true);

        // // Fully disable button object
        // if (tapToStartButton != null)
        //     tapToStartButton.gameObject.SetActive(false);

    }

    /// <summary>
    /// Hides the HowToPlay panel.
    /// </summary>
    public void HideHowToPlay()
    {
        isShowingHowToPlay = false;
        howToPlayPanel.SetActive(false);
        // // Re-enable button object
        // if (tapToStartButton != null)
        //     tapToStartButton.gameObject.SetActive(true);
    }

    /// <summary>
    /// Called when user clicks outside the image in the HowToPlay panel.
    /// Attach this to background Button.
    /// </summary>
    public void OnBackgroundClicked()
    {
        if (isShowingHowToPlay)
        {
            HideHowToPlay();
        }
    }

    public void ShowLeaderboard()
    {
        leaderboardPanel.SetActive(true);
        // // Disable tap to start button
        // if (tapToStartButton != null)
        //     tapToStartButton.gameObject.SetActive(false);
    }
    
    public void HideLeaderboard()
    {
        leaderboardPanel.SetActive(false);
        // // Re-enable tap to start button
        // if (tapToStartButton != null)
        //     tapToStartButton.gameObject.SetActive(true);
    }
}
