using UnityEngine;

public class GOAudioManager : MonoBehaviour
{
    public static GOAudioManager instance;

    public AudioSource bgmSource;  // Background music AudioSource
    public AudioSource gameOverMusicSource;  // Game over music AudioSource

    // Other variables and methods in AudioManager...

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Other methods...

    public void PlayGameOverMusic()
    {
        if (gameOverMusicSource != null && !gameOverMusicSource.isPlaying)
        {
            // Stop the background music
            if (bgmSource != null)
            {
                bgmSource.Stop();
            }

            // Play the game over music
            gameOverMusicSource.Play();
        }
    }
}
