using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    private void Start()
    {
        // Đảm bảo SoundManager tồn tại
        if (SoundManager.Instance == null)
        {
            // Tạo SoundManager nếu chưa có
            GameObject soundManagerObj = new GameObject("SoundManager");
            soundManagerObj.AddComponent<SoundManager>();
        }

        // Play menu music when Main Menu loads
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.StopBackgroundMusic(); // Stop game music if playing
            SoundManager.Instance.PlayMenuMusic();
        }
    }

    private void OnDestroy()
    {
        // Stop menu music when leaving Main Menu
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.StopBackgroundMusic();
        }
    }
}

