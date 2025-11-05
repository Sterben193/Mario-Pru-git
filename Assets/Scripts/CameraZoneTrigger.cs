using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private float newCameraY;
    private SideScrollingCamera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the camera script when the game starts
        mainCamera = Camera.main.GetComponent<SideScrollingCamera>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the Player entered the trigger
        if (other.CompareTag("Player") && mainCamera != null)
        {
            // Tell the camera to move to the new Y position!
            mainCamera.SetCameraY(newCameraY);
        }
    }
}
