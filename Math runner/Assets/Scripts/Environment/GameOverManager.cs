using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public ScoringManager scoringManager; // Reference to the scoring manager.
    public GameOverUIManager gameOverUIManager;
    public GOAudioManager audioManager;  // Reference to the AudioManager

    public float zPositionThreshold = 30f; // Minimum z position for the game over condition.

    private bool isGameOver = false;

    void Update()
    {
        if (!isGameOver && scoringManager.TotalScore > 0)
        {
            isGameOver = true;
        }
        // Check if the player's z position is above the threshold.
        if (isGameOver && scoringManager.TotalScore <= 0 && scoringManager.scoreText.gameObject.activeSelf && transform.position.z > zPositionThreshold)
        {
            // Trigger game over.
            GameOver();
        }
    }

    void GameOver()
    {
        // Show the game over panel using the GameOverUIManager.
        gameOverUIManager.ShowGameOverPanel(scoringManager.TotalScore);

        // Stop player movement and trigger idle animation.
        PlayerMove playerMove = FindObjectOfType<PlayerMove>();
        if (playerMove != null)
        {
            playerMove.enabled = false; // Disable player movement script.

            // Trigger idle animation if you have an Animator component.
            Animator playerAnimator = playerMove.GetComponent<Animator>();
            if (playerAnimator != null)
            {
                playerAnimator.SetBool("IsIdle", true);
            }

        }

        // Play the game over music
        if (audioManager != null)
        {
            audioManager.PlayGameOverMusic();
        }



    }

}
