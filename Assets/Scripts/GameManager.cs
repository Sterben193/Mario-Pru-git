using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public bool isInvincible = false;
    public static GameManager Instance { get; private set; }
    public int world { get; private set; } = 1;
    public int stage { get; private set; } = 1;
    public int lives { get; private set; } = 3;
    public int coins { get; private set; } = 0;
    public int score { get; private set; } = 0;
    public int highScore { get; private set; } = 0;

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

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        LoadHighScore();
        NewGame();
    }

    public void NewGame()
    {
        lives = 3;
        score = 0;
        coins = 0;
        LoadLevel(1, 1);
    }

    public void GameOver()
    {
        NewGame();
    }

    public void LoadLevel(int world, int stage)
    {
        this.world = world;
        this.stage = stage;
        SceneManager.LoadScene($"{world}-{stage}");
    }

    public void NextLevel()
    {
        LoadLevel(world, stage + 1);
    }

    public void ResetLevel(float delay)
    {
        CancelInvoke(nameof(ResetLevel));
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        CheckAndSaveHighScore(); // Kiểm tra và lưu high score trước khi reset
        lives--;
        score = 0;      // Reset điểm khi chết
        coins = 0;      // Reset xu khi chết

        if (lives > 0)
        {
            SceneManager.LoadSceneAsync(0); ;  // Quay về map 1-1
        }
        else
        {
            SceneManager.LoadSceneAsync(0);
        }
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