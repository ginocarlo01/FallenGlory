using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] soundClips;
    public AudioSource bgMusic;
    public static SFXManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Ensure we have a reference to the AudioSource component on this GameObject
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("AudioSource component not found on AudioManager or assigned in the inspector.");
                return;
            }
        }
    }

    public void PlaySound(int soundIndex)
    {
        if (soundIndex >= 0 && soundIndex < soundClips.Length)
        {
            Debug.Log("Played"); 
            audioSource.PlayOneShot(soundClips[soundIndex]);
        }
        else
        {
            Debug.LogError("Invalid sound index: " + soundIndex);
        }
    }

    public void StopBGMusic()
    {
        bgMusic.Stop();
    }

    public void StartLevelMusic()
    {

    }

    public void StopLevelMusic()
    {

    }
}
