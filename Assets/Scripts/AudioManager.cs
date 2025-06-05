using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource conveyorAudioSource;
    public AudioSource bgMusicSource;

    public AudioClip conveyorSound;
    public AudioClip backgroundMusic;

    void Start()
    {
        // Play background music
        if (bgMusicSource != null && backgroundMusic != null)
        {
            bgMusicSource.clip = backgroundMusic;
            bgMusicSource.loop = true;
            bgMusicSource.volume = 0.5f;
            bgMusicSource.Play();
        }

        // Play conveyor sound
        if (conveyorAudioSource != null && conveyorSound != null)
        {
            conveyorAudioSource.clip = conveyorSound;
            conveyorAudioSource.loop = true;
            conveyorAudioSource.volume = 1f;
            conveyorAudioSource.Play();
        }
    }
}
