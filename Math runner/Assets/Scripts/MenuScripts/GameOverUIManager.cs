using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{
    public PlayerMove playerMove; // Drag and drop the PlayerMove script onto this field in the Unity Editor.

    public GameObject gameOverPanel;
    public GameObject highScoreCanvas; // Drag and drop the HighScoreCanvas GameObject onto this field in the Unity Editor.
    public GameObject ScoringManager;

    void Start()
    {
        // Disable the game over panel and high score canvas initially.
        gameOverPanel.SetActive(false);
        
    }




public void ShowHighScoreCanvas()
    {
        // Show the high score canvas.
        highScoreCanvas.SetActive(true);
        ScoringManager.SetActive(false);
    }

    public void ShowGameOverPanel(float distance)
    {
        // Show the game over panel.

        // Hide the high score canvas.
        if (highScoreCanvas.activeSelf)
        {
            gameOverPanel.SetActive(false);
        }
        else
        {
            gameOverPanel.SetActive(true);
        }
    }

    

    public void RestartGame()
    {
        // Reload the current scene to restart the game.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        // Quit the application (works in standalone builds).
    }
}
