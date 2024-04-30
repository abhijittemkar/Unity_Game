using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    private bool isSoundMuted;

    private const string SoundMuteKey = "SoundMuteKey";

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;

        // Load sound mute state from PlayerPrefs
        isSoundMuted = PlayerPrefs.GetInt(SoundMuteKey, 0) == 1;
        MuteAllSounds(isSoundMuted);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Mute sounds whenever a new scene is loaded
        MuteAllSounds(isSoundMuted);
    }

    public bool IsSoundMuted
    {
        get { return isSoundMuted; }
        set
        {
            isSoundMuted = value;
            MuteAllSounds(isSoundMuted);

            // Save sound mute state to PlayerPrefs
            PlayerPrefs.SetInt(SoundMuteKey, isSoundMuted ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    private void MuteAllSounds(bool mute)
    {
        // Toggle mute for all AudioSources in the scene
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        foreach (var audioSource in allAudioSources)
        {
            audioSource.mute = mute;
        }
    }
}
