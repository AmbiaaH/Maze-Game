using UnityEngine;
using UnityEngine.SceneManagement; // For loading scenes

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu; // Assign in Inspector
    public bool isPaused = false;

    private void Start()
    {
        // Ensure the pause menu is hidden at the start
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Check for Escape key to toggle pause
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

    public void PauseGame()
    {
        pauseMenu.SetActive(true); // Show the pause menu
        Time.timeScale = 0f; // Stop game time
        isPaused = true;
        Cursor.lockState = CursorLockMode.None; // Unlock cursor
        Cursor.visible = true; // Show cursor
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f; // Resume game time
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor
        Cursor.visible = false; // Hide cursor
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Resume game time before switching scenes
        SceneManager.LoadScene(0); // Load scene 0 (Main Menu)
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit(); // Quit the application
    }
}
