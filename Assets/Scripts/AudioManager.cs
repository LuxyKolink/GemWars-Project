using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    public AudioClip battleMusic;
    private AudioSource musicSource;
    
    void Awake()
    {
        // Singleton pattern to keep the audio manager across scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        // Create audio source for music
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.volume = 0.5f;
    }
    
    public void PlayBattleMusic()
    {
        if (battleMusic != null)
        {
            musicSource.clip = battleMusic;
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("Battle music clip not assigned!");
        }
    }
    
    public void StopMusic()
    {
        musicSource.Stop();
    }
    
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = Mathf.Clamp01(volume);
    }
}
