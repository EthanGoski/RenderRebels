using UnityEngine;

public class CursorManager : MonoBehaviour
{
    void Start()
    {
        // Make sure the cursor is visible and not locked when the game starts
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;  // Prevent the cursor from being locked to the center
    }

    void Update()
    {
        // Check if the player clicks on the game window, and keep the cursor visible
        if (Input.GetMouseButtonDown(0))  // Left-click
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;  // Ensure cursor is not locked
        }
    }

    // Optional: Ensure cursor is visible when the game is paused
    void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            Cursor.visible = true;  // Ensure cursor remains visible after pause
            Cursor.lockState = CursorLockMode.None;
        }
    }
}