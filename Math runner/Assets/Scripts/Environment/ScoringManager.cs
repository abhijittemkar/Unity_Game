using UnityEngine;
using TMPro;

public class ScoringManager : MonoBehaviour
{
    public float TotalScore;
    private bool canUpdateScore = true;
    private float lastUpdateTime;

    // Reference to the TextMeshPro text component to display the score.
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        // Initialize the score text on the UI.
        UpdateScoreText();
    }

    public void UpdateScore(string selectedOperator, int operand)
    {
        // Check if updating the score is allowed.
        if (canUpdateScore)
        {
            // Perform scoring logic here based on the operator and operand.
            // For example, you can use a switch statement to handle different operators.
            switch (selectedOperator)
            {
                case "+":
                    TotalScore += operand;
                    break;
                case "-":
                    TotalScore -= operand;
                    break;
                case "*":
                    TotalScore *= operand;
                    break;
                case "/":
                    TotalScore /= operand;
                    break;
                default:
                    // Handle unknown operators if needed.
                    break;
            }

            // Log the updated total score.
            Debug.Log($"Total Score: {TotalScore}");

            // Update the UI text with the new score.
            UpdateScoreText();

            // Update the last update time and prevent further updates for the cooldown period.
            lastUpdateTime = Time.time;
            canUpdateScore = false;

            // Start a coroutine to re-enable score updates after the cooldown time.
            StartCoroutine(EnableScoreUpdatesAfterCooldown());
        }
    }

    private System.Collections.IEnumerator EnableScoreUpdatesAfterCooldown()
    {
        // Adjust the cooldown time as needed.
        float cooldownTime = 0.5f;

        yield return new WaitForSeconds(cooldownTime);

        // Re-enable score updates.
        canUpdateScore = true;
    }

    private void UpdateScoreText()
    {
        // Update the TextMeshPro text component with the current score.
        if (scoreText != null)
        {
            scoreText.text = $"Score: {TotalScore}";
        }
    }
}
