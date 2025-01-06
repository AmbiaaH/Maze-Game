using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour
{
    private const string LastLevelKey = "LastLevel";

    // Reloads the last level the player was on before the LoseScreen
    public void RetryLevel()
    {
        // Lock the cursor for gameplay and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Load the last saved level from PlayerPrefs
        int lastLevelIndex = PlayerPrefs.GetInt(LastLevelKey, 0); // Default to 0 if no value is found
        SceneManager.LoadScene(lastLevelIndex);
    }

    // Load the main menu scene
    public void LoadMainMenu()
    {
        // Unlock the cursor and make it visible for the main menu
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Load the main menu scene
        SceneManager.LoadScene("Main Menu");
    }

    private void Start()
    {
        // Ensure the cursor is unlocked and visible when entering this scene
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Save the current level index before switching to the LoseScreen scene
    public static void SaveCurrentLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt(LastLevelKey, currentLevelIndex);
        PlayerPrefs.Save(); // Ensure changes are saved
    }
}
