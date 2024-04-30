using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject highScoreCanvas;
    public GameObject mainMenuContent;

    public void OnCharactersButtonClicked()
    {
        SceneManager.LoadScene("Characters");
        Debug.Log("Button clicked...");
    }

    public void OnHighScoreButtonClicked()
    {
        // Deactivate the main menu content.
            mainMenuContent.SetActive(false);

        // Activate the high score canvas.
            highScoreCanvas.SetActive(true);

        Debug.Log("High score Button clicked...");
    }
}


