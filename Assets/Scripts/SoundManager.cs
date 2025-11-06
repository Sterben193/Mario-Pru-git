using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Sound Clips")]
    public AudioClip jumpSound;
    public AudioClip gameOverSound;
    public AudioClip playerDieSound;
    public AudioClip victorySound;
    public AudioClip powerupSound;
    public AudioClip coinSound;
    public AudioClip growSound;
    public AudioClip stageClearSound;
    public AudioClip stompSound;

    [Header("Background Music")]
    public AudioClip backgroundMusic; // Ground Theme (Game)
    public AudioClip menuMusic; // Menu Background Music

    private AudioSource audioSource; // Cho sound effects
    private AudioSource musicSource; // Cho background music

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Setup AudioSource cho sound effects
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
        audioSource.volume = 0.5f; // Điều chỉnh volume sound effects

        // Setup AudioSource riêng cho background music
        GameObject musicObject = new GameObject("MusicSource");
        musicObject.transform.SetParent(transform);
        musicSource = musicObject.AddComponent<AudioSource>();
        
        musicSource.playOnAwake = false;
        musicSource.loop = true; // Loop background music
        musicSource.volume = 0.3f; // Volume nhạc nền (thấp hơn sound effects)
    }

    public void PlaySound(AudioClip clip, float volume = 1f)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip, volume);
        }
    }

    // Helper methods cho từng loại sound
    public void PlayJump() => PlaySound(jumpSound);
    public void PlayGameOver() => PlaySound(gameOverSound);
    public void PlayPlayerDie() => PlaySound(playerDieSound);
    public void PlayVictory() => PlaySound(victorySound);
    public void PlayPowerup() => PlaySound(powerupSound);
    public void PlayCoin() => PlaySound(coinSound);
    public void PlayGrow() => PlaySound(growSound);
    public void PlayStageClear() => PlaySound(stageClearSound);
    public void PlayStomp() => PlaySound(stompSound);

    // Background Music Methods
    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && musicSource != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    public void PauseBackgroundMusic()
    {
        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Pause();
        }
    }

    public void ResumeBackgroundMusic()
    {
        if (musicSource != null)
        {
            if (musicSource.time > 0f)
            {
                // Nếu đã có time nghĩa là đã từng play, chỉ cần unpause
                musicSource.UnPause();
            }
            else
            {
                // Nếu chưa play, gọi PlayBackgroundMusic
                PlayBackgroundMusic();
            }
        }
    }

    public void SetMusicVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = Mathf.Clamp01(volume);
        }
    }

    // Menu Music Methods
    public void PlayMenuMusic()
    {
        if (menuMusic != null && musicSource != null)
        {
            musicSource.clip = menuMusic;
            musicSource.Play();
        }
        else if (backgroundMusic != null && musicSource != null)
        {
            // Fallback: dùng background music nếu không có menu music
            musicSource.clip = backgroundMusic;
            musicSource.Play();
        }
    }
}

