using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour
{
    // Called when the script is initialized
    private void Start()
    {
        // Unlock and make the cursor visible when entering the LoseScreen scene
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Loads the last saved level using PlayerPrefs
    public void LoadGame()
    {
        // Lock the cursor for gameplay and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Get the last saved level index, default to 0 if not found
        int lastLevelIndex = PlayerPrefs.GetInt("LastLevel", 0);
        SceneManager.LoadScene(lastLevelIndex);
    }

    // Loads the main level (assumed to be the first level)
    public void LoadMainLevel()
    {
        // Lock the cursor for gameplay and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Load the first level called "Maze"
        SceneManager.LoadScene("Maze");
    }
}
