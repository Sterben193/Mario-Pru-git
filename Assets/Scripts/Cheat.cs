using UnityEngine;

public class Cheat : MonoBehaviour
{
    private void Update()
    {
        // Shift + 1: Bật/tắt bất tử
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.Instance.isInvincible = !GameManager.Instance.isInvincible;
            Debug.Log("Invincible Mode: " + (GameManager.Instance.isInvincible ? "ON" : "OFF"));
        }

        // Shift + 2: Tăng 10 coins
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha2))
        {
            for (int i = 0; i < 10; i++)
            {
                GameManager.Instance.AddCoin();
            }
            Debug.Log("Added 10 coins. Total: " + GameManager.Instance.coins);
        }
    }
}
