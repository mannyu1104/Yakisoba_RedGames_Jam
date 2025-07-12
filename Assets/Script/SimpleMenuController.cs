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
    public Button howToPlayButton;         // "How to Play" button
    public Button closeHowToPlayButton;    // "X" close button on top right
    public Button tapToStartButton; // Tap to start button

    [Header("Scene Settings")]
    public string gameSceneName = "GameScene";

    private bool isShowingHowToPlay = false;
    private bool hasStarted = false;

    void Start()
    {
        // Hide HowToPlay at start
        howToPlayPanel.SetActive(false);

        // Setup button listeners
        howToPlayButton.onClick.AddListener(ShowHowToPlay);
        closeHowToPlayButton.onClick.AddListener(HideHowToPlay);
    }


    void Update()
    {
        if (hasStarted || isShowingHowToPlay)
            return;

    #if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // 💡 检查是否触碰 UI
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;

            StartGame();
        }
    #else
        if (Input.GetMouseButtonDown(0))
        {
            // 💡 检查是否点到 UI
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            StartGame();
        }
    #endif
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

        // Fully disable button object
        if (tapToStartButton != null)
            tapToStartButton.gameObject.SetActive(false);

    }

    /// <summary>
    /// Hides the HowToPlay panel.
    /// </summary>
    public void HideHowToPlay()
    {
        isShowingHowToPlay = false;
        howToPlayPanel.SetActive(false);
        // Re-enable button object
        if (tapToStartButton != null)
            tapToStartButton.gameObject.SetActive(true);
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
}
