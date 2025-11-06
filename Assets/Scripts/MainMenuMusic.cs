using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    [Header("Music Settings")]
    public AudioClip menuMusic; // Kéo file nhạc vào đây
    public float volume = 0.5f; // Volume nhạc (0.0 - 1.0)

    private AudioSource audioSource;

    private void Awake()
    {
        // Tạo AudioSource nếu chưa có
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Cấu hình AudioSource
        audioSource.playOnAwake = false;
        audioSource.loop = true; // Loop nhạc nền
        audioSource.volume = volume;
        audioSource.clip = menuMusic;
    }

    private void Start()
    {
        // Phát nhạc khi scene load
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (menuMusic != null && audioSource != null)
        {
            audioSource.clip = menuMusic;
            audioSource.volume = volume;
            audioSource.Play();
            Debug.Log("Main Menu music started playing!");
        }
        else
        {
            Debug.LogWarning("Menu music clip is not assigned or AudioSource is missing!");
        }
    }

    public void StopMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void SetVolume(float newVolume)
    {
        volume = Mathf.Clamp01(newVolume);
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }
}

