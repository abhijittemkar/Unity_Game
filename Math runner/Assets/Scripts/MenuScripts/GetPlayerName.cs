using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetPlayerName : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;

    private void Start()
    {
        // Access the saved player name from PlayerPrefs using the same key.
        string playerName = PlayerPrefs.GetString("PlayerName", "Player");

        // Display "Player Name: " + playerName in the TextMeshProUGUI element.
        playerNameText.text = "Player Name: " + playerName;
    }
}
