using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinsText;

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
            Debug.Log("Score: " + GameManager.Instance.score + " | Coins: " + GameManager.Instance.coins);
            scoreText.text = "SCORE: " + GameManager.Instance.score.ToString("000000");
            coinsText.text = "COINS: x" + GameManager.Instance.coins.ToString("00");
          
        }
    }
}
