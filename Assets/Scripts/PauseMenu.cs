using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;  // Reference to the Pause Menu UI
    public bool isPaused = false; // Track whether the game is paused

    void Start()
    {
        pauseMenu.SetActive(false);  // Hide the pause menu at the start
        Cursor.lockState = CursorLockMode.Locked;  // Lock the cursor at the start
        Cursor.visible = false;  // Hide the cursor at the start
    }

    void Update()
    {
        // Check for the Escape key to toggle pause state
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();  // Resume the game if it is paused
            }
            else
            {
                PauseGame();   // Pause the game if it is not paused
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);   // Show the pause menu
        Time.timeScale = 0f;         // Pause the game by freezing time
        isPaused = true;             // Set the game to paused state
        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor when paused
        Cursor.visible = true;       // Make the cursor visible
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);  // Hide the pause menu
        Time.timeScale = 1f;         // Resume the game by setting time back to normal
        isPaused = false;            // Set the game to unpaused state
        Cursor.lockState = CursorLockMode.Locked;  // Lock the cursor for gameplay
        Cursor.visible = false;      // Hide the cursor during gameplay
    }
}