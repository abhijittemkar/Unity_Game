using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HSWindow : MonoBehaviour
{
   
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    private void Start()
    {
        // Access the saved player name from PlayerPrefs using the same key.
        string playerName = PlayerPrefs.GetString("PlayerName", "Player");

        // Access the saved high score from PlayerPrefs using the key "HighScore".
        float highScore = PlayerPrefs.GetFloat("HighScore", 0f);

        // Display "Player Name: " + playerName in the TextMeshProUGUI element.
        playerNameText.text = "Player Name: " + playerName;

        // Display "High Score: " + highScore in the TextMeshProUGUI element.
        highScoreText.text = "High Score: " + highScore;

        // Log the player name and high score to the console.
        Debug.Log("Player Name: " + playerName);
        Debug.Log("High Score: " + highScore);
    }


    public void OnMainMenuButtonClicked()
    {
        Debug.Log("Main menu clicked");
        SceneManager.LoadScene("MainMenu");

    }


}
