using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public bool isInvincible = false;
    public static GameManager Instance { get; private set; }

    [Header("Game Stats")]
    public int world { get; private set; } = 1;
    public int stage { get; private set; } = 1;
    public int lives { get; private set; } = 3;
    public int coins { get; private set; } = 0;
    public int score { get; private set; } = 0;
    public int highScore { get; private set; } = 0;

    [Header("UI")]
    public GameObject gameOverPanel;   // ✅ Kéo Canvas GameOver vào đây (hoặc để null để tự tìm)
    public GameObject congratulationPanel; // ✅ Kéo Canvas Congratulation vào đây (hoặc để null để tự tìm)

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        LoadHighScore();
        
        // Đảm bảo SoundManager tồn tại
        if (SoundManager.Instance == null)
        {
            // Tạo SoundManager nếu chưa có
            GameObject soundManagerObj = new GameObject("SoundManager");
            soundManagerObj.AddComponent<SoundManager>();
        }
        
        // Play background music
        if (SoundManager.Instance != null)
            SoundManager.Instance.PlayBackgroundMusic();
        
        NewGame();
    }

    public void NewGame()
    {
        lives = 3;
        score = 0;
        coins = 0;
        LoadLevel(1, 1);
    }

    public void LoadLevel(int world, int stage)
    {
        this.world = world;
        this.stage = stage;
        Time.timeScale = 1f;   // ✅ Đảm bảo game không bị freeze
        
        // Ẩn các UI panel khi load level mới
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
        
        if (congratulationPanel != null)
        {
            congratulationPanel.SetActive(false);
            // Reset reference để tìm lại khi cần (quan trọng khi load scene mới)
            if (congratulationPanel.scene.name != $"{world}-{stage}")
            {
                congratulationPanel = null;
            }
        }
        
        // Resume background music khi load level mới
        if (SoundManager.Instance != null)
            SoundManager.Instance.PlayBackgroundMusic();
        
        SceneManager.LoadScene($"{world}-{stage}");
    }

    // ✅ HÀM GỌI KHI HOÀN THÀNH LEVEL
    public void LevelComplete(int nextWorld, int nextStage)
    {
        CheckAndSaveHighScore(); // Lưu điểm cao nhất
        
        Debug.Log($"LevelComplete called! Current: World {world}, Stage {stage} | Next: World {nextWorld}, Stage {nextStage}");
        
        // Kiểm tra nếu hoàn thành map 1-3 (world 1, stage 3)
        if (world == 1 && stage == 3)
        {
            Debug.Log("Victory condition met! Showing Congratulation...");
            ShowCongratulation();
        }
        else
        {
            Debug.Log($"Not victory condition. Loading next level: {nextWorld}-{nextStage}");
            // Nếu không phải map cuối, load level tiếp theo
            LoadLevel(nextWorld, nextStage);
        }
    }

    // ✅ HIỂN THỊ MÀN HÌNH CHÚC MỪNG
    public void ShowCongratulation()
    {
        Debug.Log("ShowCongratulation() called!");
        
        // Play victory sound
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.StopBackgroundMusic(); // Stop game music
            SoundManager.Instance.PlayVictory();
        }
        
        // Tìm Congratulation Canvas nếu chưa được gán
        if (congratulationPanel == null)
        {
            Debug.Log("congratulationPanel is null, searching for 'Congratulation' GameObject...");
            
            GameObject congratulationCanvas = null;
            
            // Thử tìm trong scene hiện tại (kể cả inactive)
            UnityEngine.SceneManagement.Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            GameObject[] rootObjects = currentScene.GetRootGameObjects();
            
            foreach (GameObject rootObj in rootObjects)
            {
                // Tìm trong root objects
                if (rootObj.name == "Congratulation")
                {
                    congratulationCanvas = rootObj;
                    break;
                }
                
                // Tìm trong children (recursive)
                Transform found = rootObj.transform.Find("Congratulation");
                if (found != null)
                {
                    congratulationCanvas = found.gameObject;
                    break;
                }
            }
            
            // Nếu vẫn không tìm thấy, thử GameObject.Find (chỉ tìm active)
            if (congratulationCanvas == null)
            {
                congratulationCanvas = GameObject.Find("Congratulation");
            }
            
            if (congratulationCanvas != null)
            {
                congratulationPanel = congratulationCanvas;
                Debug.Log("Found Congratulation Canvas: " + congratulationCanvas.name + " | Active: " + congratulationCanvas.activeSelf);
            }
            else
            {
                Debug.LogError("Congratulation Canvas not found! Please assign it in GameManager or name it 'Congratulation'");
                Debug.LogError("Make sure Canvas 'Congratulation' exists in scene 1-3!");
                Debug.LogError("Current scene: " + currentScene.name);
                return;
            }
        }
        else
        {
            Debug.Log("congratulationPanel is assigned: " + congratulationPanel.name + " | Active: " + congratulationPanel.activeSelf);
        }
        
        if (congratulationPanel != null)
        {
            // Đảm bảo Canvas và parent được active
            if (congratulationPanel.transform.parent != null)
            {
                congratulationPanel.transform.parent.gameObject.SetActive(true);
            }
            
            Time.timeScale = 0f; // Freeze game
            congratulationPanel.SetActive(true); // Hiện UI Congratulation
            
            // Force update để đảm bảo Canvas hiển thị
            Canvas canvas = congratulationPanel.GetComponent<Canvas>();
            if (canvas != null)
            {
                canvas.enabled = true;
            }
            
            Debug.Log("Congratulation panel activated! Active: " + congratulationPanel.activeSelf + " | Enabled: " + (canvas != null ? canvas.enabled.ToString() : "N/A"));
        }
        else
        {
            Debug.LogError("Cannot show Congratulation - congratulationPanel is still null!");
        }
    }

    public void GameOver()
    {
        Debug.Log("GameOver() called!");
        CheckAndSaveHighScore();       // Lưu điểm cao nhất
        
        // Stop background music
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.StopBackgroundMusic();
            SoundManager.Instance.PlayGameOver();
        }
        
        // Tìm GameOver Canvas nếu chưa được gán
        if (gameOverPanel == null)
        {
            Debug.Log("gameOverPanel is null, searching for 'GameOver' GameObject...");
            GameObject gameOverCanvas = GameObject.Find("GameOver");
            if (gameOverCanvas != null)
            {
                gameOverPanel = gameOverCanvas;
                Debug.Log("Found GameOver Canvas: " + gameOverCanvas.name);
            }
            else
            {
                Debug.LogError("GameOver Canvas not found! Please assign it in GameManager or name it 'GameOver'");
                return;
            }
        }
        else
        {
            Debug.Log("gameOverPanel is assigned: " + gameOverPanel.name);
        }
        
        if (gameOverPanel != null)
        {
            Time.timeScale = 0f;           // Freeze game
            gameOverPanel.SetActive(true); // Hiện UI Game Over
            Debug.Log("GameOver panel activated! Active: " + gameOverPanel.activeSelf);
        }
        else
        {
            Debug.LogError("Cannot show GameOver - gameOverPanel is still null!");
        }
    }

    public void ResetLevel(float delay)
    {
        CancelInvoke(nameof(ResetLevel));
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        CheckAndSaveHighScore(); // Kiểm tra và lưu high score trước khi reset
        
        Debug.Log("Player died! Showing GameOver...");
        score = 0;
        coins = 0;
      
        // Hiện GameOver ngay khi chết (không cần kiểm tra lives)
        GameOver();

    }

    // ✅ HÀM GỌI KHI BẤM BUTTON MAIN MENU (từ GameOver hoặc Congratulation)
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;                // gỡ freeze
        
        // Ẩn tất cả UI panels trước khi load scene
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
        
        if (congratulationPanel != null)
            congratulationPanel.SetActive(false);
        
        // Stop game music và play menu music
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.StopBackgroundMusic();
            SoundManager.Instance.PlayMenuMusic();
        }
        
        // Tìm scene MainMenu (có thể là scene index 0 hoặc tên "MainMenu")
        SceneManager.LoadScene(0); // Hoặc SceneManager.LoadScene("MainMenu") nếu scene có tên đó
    }

    // ✅ HÀM RESET GAME (nếu muốn thêm nút Restart)
    public void RestartGame()
    {
        Time.timeScale = 1f;
        NewGame();
    }

    public void AddCoin()
    {
        coins++;
        AddScore(10);

        if (coins == 100)
        {
            coins = 0;
            AddLife();
        }
    }

    public void AddLife()
    {
        lives++;
    }

    public void AddScore(int points)
    {
        score += points;
    }

    private void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void CheckAndSaveHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }
}
