using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Add the AudioSources through the Unity Editor
    public AudioSource sfxHover;
    public AudioSource sfxClick;
    public AudioSource sfxSwoosh;

    private void Start()
    {
        // Optionally, you can populate AudioSources dynamically in Start()
        // sfxHover = GetComponentInChildren<AudioSource>();
        // sfxClick = GetComponentInChildren<AudioSource>();
        // sfxSwoosh = GetComponentInChildren<AudioSource>();
    }

    public void ToggleMute(bool mute)
    {
        // Toggle mute for each AudioSource
        ToggleMuteForSource(sfxHover, mute);
        ToggleMuteForSource(sfxClick, mute);
        ToggleMuteForSource(sfxSwoosh, mute);

        // Toggle mute for any other sounds you have in the AudioManager
    }

    // Add this new method to toggle mute for other sounds as needed
    private void ToggleMuteForSource(AudioSource audioSource, bool mute)
    {
        if (audioSource != null) // Ensure AudioSource is not null
            audioSource.mute = mute;
    }

}

