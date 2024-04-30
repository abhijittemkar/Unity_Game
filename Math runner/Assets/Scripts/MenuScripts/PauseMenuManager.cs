using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseGameCanvas; // Reference to the PauseGameCanvas GameObject.


   

    // Function to handle the pause functionality.
    public void Pause()
    {
        pauseGameCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        pauseGameCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        // Reload the current scene to restart the game.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void BackToMainMenu()
    {
        // Load the main menu scene.
        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with the actual scene name.
        Time.timeScale = 1;

    }
}
