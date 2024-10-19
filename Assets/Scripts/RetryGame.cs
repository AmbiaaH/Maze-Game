using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour
{
    private void Start()
    {
        // Unlock and show the cursor when entering the LoseScreen scene
        Cursor.lockState = CursorLockMode.None;  // Unlocks the cursor
        Cursor.visible = true;                   // Makes the cursor visible
    }

    public void LoadGame()
    {
        // Optionally lock the cursor again if needed for the gameplay
        Cursor.lockState = CursorLockMode.Locked;  // Lock cursor for gameplay
        Cursor.visible = false;                    // Hide cursor in gameplay

        // Get the last saved level from PlayerPrefs and load it
        int lastLevelIndex = PlayerPrefs.GetInt("LastLevel", 0);  // Default to 0 if no level is saved
        SceneManager.LoadScene(lastLevelIndex);
    }

    public void LoadMainLevel()
    {
        // Optionally lock the cursor again if needed for the gameplay
        Cursor.lockState = CursorLockMode.Locked;  // Lock cursor for gameplay
        Cursor.visible = false;                    // Hide cursor in gameplay

        // Load the first level called "Maze"
        SceneManager.LoadScene("Maze");  // Replace with your first scene name
    }
}