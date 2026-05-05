using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public KnifePieceTracker tracker;
    public static bool GamePaused = false;

    private PlayerInfo plrInfo;

    public static GameObject MainPauseMenu;

    private void Awake()
    {
        plrInfo = GameObject.FindGameObjectWithTag("PlayerInfo").GetComponent<PlayerInfo>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            tracker.UpdateText(plrInfo.KnifePieces);
            GamePause();
        }
    }

    public void GamePause()
    {
        if (!GamePaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        GamePaused = !GamePaused;
    }

    public void Restart()
    {
        GamePause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
