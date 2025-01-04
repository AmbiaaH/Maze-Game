using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Reference to the pause menu UI
    public GameObject pauseMenu;

    // Boolean flag to track whether the game is paused
    public bool isPaused = false;

    // Called when the script is initialized
    private void Start()
    {
        // Ensure the pause menu is hidden at the start of the game
        pauseMenu.SetActive(false);

        // Lock the cursor and hide it at the start
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Called every frame to check for input
    private void Update()
    {
        // Check for the "Escape" key press to toggle the pause state
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                // Resume the game if it's paused
                ResumeGame();
            }
            else
            {
                // Pause the game if it's running
                PauseGame();
            }
        }
    }

    // Function to pause the game
    public void PauseGame()
    {
        // Show the pause menu
        pauseMenu.SetActive(true);

        // Pause the game by setting the time scale to 0
        Time.timeScale = 0f;

        // Set the paused state to true
        isPaused = true;

        // Unlock and make the cursor visible during pause
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Function to resume the game
    public void ResumeGame()
    {
        // Hide the pause menu
        pauseMenu.SetActive(false);

        // Resume the game by setting the time scale to 1 (normal speed)
        Time.timeScale = 1f;

        // Set the paused state to false
        isPaused = false;

        // Lock the cursor for gameplay and hide it again
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
