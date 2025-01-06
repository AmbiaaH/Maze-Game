using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Assign the Pause Menu UI in the Inspector
    public bool isPaused = false;

    void Update()
    {
        // Toggle pause menu when the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        // Deactivate the pause menu UI
        pauseMenuUI.SetActive(false);

        // Resume the game
        Time.timeScale = 1f;
        isPaused = false;

        // Unlock and show the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void PauseGame()
    {
        // Activate the pause menu UI
        pauseMenuUI.SetActive(true);

        // Pause the game
        Time.timeScale = 0f;
        isPaused = true;

        // Unlock and show the cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadMainMenu()
    {
        // Resume time before loading the main menu
        Time.timeScale = 1f;

        // Unlock and show the cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Load the main menu scene
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
        Debug.Log("Game Quit!");
    }
}
