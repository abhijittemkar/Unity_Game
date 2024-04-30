using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public Button[] selectButtons;
    private Button selectedButton;
    private string selectedButtonKey = "SelectedButton";

    void Start()
    {
        // Load the saved selected button when the game starts
        string savedButtonName = PlayerPrefs.GetString(selectedButtonKey, "");
        if (!string.IsNullOrEmpty(savedButtonName))
        {
            selectedButton = FindButtonByName(savedButtonName);
            if (selectedButton != null)
            {
                ChangeButtonAppearance(selectedButton);
                Debug.Log($"Loaded Selected Button: {selectedButton.name}");
            }
        }

        foreach (Button button in selectButtons)
        {
            button.onClick.AddListener(() => OnSelectButtonClick(button));
        }
    }

    void OnSelectButtonClick(Button clickedButton)
    {
        ChangeButtonAppearance(clickedButton);
        selectedButton = clickedButton;

        PlayerPrefs.SetString(selectedButtonKey, selectedButton.name);
        PlayerPrefs.Save();

        Debug.Log($"Selected Button: {selectedButton.name}");

        // Perform additional actions based on the selected button if needed.

        // Load the "GamePlay" scene when a button is clicked.
        SceneManager.LoadScene("GamePlay");
    }

    void ChangeButtonAppearance(Button clickedButton)
    {
        foreach (Button button in selectButtons)
        {
            ChangeButtonColor(button, new Color(1f, 0.686f, 0f, 1f)); // Set the color to "FFAF00" (orange)
            button.GetComponentInChildren<Text>().text = "Select";
        }

        ChangeButtonColor(clickedButton, Color.red);
        clickedButton.GetComponentInChildren<Text>().text = "Selected";
    }

    void ChangeButtonColor(Button button, Color color)
    {
        Image buttonImage = button.GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.color = color;
        }
    }

    Button FindButtonByName(string buttonName)
    {
        return System.Array.Find(selectButtons, button => button.name == buttonName);
    }
}
