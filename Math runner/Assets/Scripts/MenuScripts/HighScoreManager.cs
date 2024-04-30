using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DistanceManager : MonoBehaviour
{
    public TextMeshProUGUI distanceText; // Drag your distance TextMeshPro GameObject here in the Unity Editor.
    public TextMeshProUGUI highScoreText; // Drag your high score TextMeshPro GameObject here.
    public GameObject highScoreCanvas; // Drag your HighScoreCanvas GameObject here.
    public GameOverUIManager gameOverUIManager; // Drag and drop the GameOverUIManager script onto this field in the Unity Editor.


    private float currentDistance;
    private float highestDistance;

    void Start()
    {
        highestDistance = PlayerPrefs.GetFloat("HighScore", 0f); // Load the highest distance from PlayerPrefs.

        // Update UI with initial values.
        UpdateHighScoreText();


    }

    void Update()
    {
        // Assume distanceText.text is something like "Distance: 123.45 meters"
        // Extract the float value from the string.
        currentDistance = ExtractFloatFromDistanceText(distanceText.text);

        if (currentDistance > highestDistance)
        {
            highestDistance = currentDistance;

            // Save the new high score to PlayerPrefs.
            PlayerPrefs.SetFloat("HighScore", highestDistance);

            // Update high score UI.
            UpdateHighScoreText();

            // Log the updated high score.
            Debug.Log($"High Score Updated: {highestDistance:F2} meters");
            // Show the HighScoreCanvas (enable it).
            gameOverUIManager.ShowHighScoreCanvas();



        }
    }

    float ExtractFloatFromDistanceText(string text)
    {
        // Assume the format is "Distance: {float} meters"
        int startIndex = text.IndexOf(":") + 1;
        int endIndex = text.IndexOf("meters");

        if (startIndex >= 0 && endIndex >= 0)
        {
            string floatString = text.Substring(startIndex, endIndex - startIndex).Trim();
            if (float.TryParse(floatString, out float result))
            {
                return result;
            }
        }

        return 0f; // Default value if extraction fails.
    }

    void UpdateHighScoreText()
    {
        // Update the high score TextMeshPro text.
        if (highScoreText != null)
        {
            highScoreText.text = $"High Score: {highestDistance:F2} meters";
        }
    }
}
