using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI highScoreText;

    private void Awake()  // THÊM CÁI NÀY
    {
        if (Instance == null)
        {
            Instance = this;
            // Tìm Canvas (cha của UIManager hoặc chính nó)
            Transform canvas = GetComponentInParent<Canvas>()?.transform ?? transform;
            DontDestroyOnLoad(canvas.gameObject); 
            if (scoreText == null)
                scoreText = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();

            if (coinsText == null)
                coinsText = GameObject.Find("CoinsText")?.GetComponent<TextMeshProUGUI>();

            if (highScoreText == null)
            {
                highScoreText = GameObject.Find("HighScoreText")?.GetComponent<TextMeshProUGUI>();
                // Thử tìm với tên khác nếu không tìm thấy
                if (highScoreText == null)
                    highScoreText = GameObject.Find("HighestScore")?.GetComponent<TextMeshProUGUI>();
            }
            
            // Debug để kiểm tra
            if (highScoreText != null)
                Debug.Log("High Score Text found: " + highScoreText.name);
            else
                Debug.LogWarning("High Score Text NOT FOUND! Please check GameObject name or assign manually in Inspector.");
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (GameManager.Instance != null)
        { // Debug để test
            Debug.Log("Score: " + GameManager.Instance.score + " | Coins: " + GameManager.Instance.coins + " | High Score: " + GameManager.Instance.highScore);
            
            if (scoreText != null)
                scoreText.text = "SCORE: " + GameManager.Instance.score.ToString("000000");
            else
                Debug.LogWarning("ScoreText is NULL!");
            
            if (coinsText != null)
                coinsText.text = "COINS: x" + GameManager.Instance.coins.ToString("00");
            else
                Debug.LogWarning("CoinsText is NULL!");
            
            if (highScoreText != null)
            {
                highScoreText.text = "HIGH SCORE: " + GameManager.Instance.highScore.ToString("000000");
                Debug.Log("Updating High Score Text: " + highScoreText.text);
            }
            else
                Debug.LogWarning("HighScoreText is NULL! Cannot display high score.");
        }
        else
        {
            Debug.LogError("GameManager.Instance is NULL!");
        }
    }
}
