using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerNameHandler : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public InputField playerNameInput;
    public Button editButton;

    private void Start()
    {
        // Initialize the player name from PlayerPrefs
        playerNameText.text = PlayerPrefs.GetString("PlayerName", "Player");

        // Hook up the edit button click event
        editButton.onClick.AddListener(OnEditButtonClick);

        // Hook up the input field's onEndEdit event to save the player name
        playerNameInput.onEndEdit.AddListener(SavePlayerName);
    }

    private void OnEditButtonClick()
    {
        // Enable the input field for editing
        playerNameInput.gameObject.SetActive(true);

        // Set the input field text to the current player name
        playerNameInput.text = playerNameText.text;

        // Focus on the input field
        playerNameInput.Select();
        playerNameInput.ActivateInputField();
    }

    public void SavePlayerName(string newName)
    {
        // Save the edited player name to PlayerPrefs
        playerNameText.text = newName;
        PlayerPrefs.SetString("PlayerName", newName);

        // Disable the input field after saving
        playerNameInput.gameObject.SetActive(false);
    }
}
