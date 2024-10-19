using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToNextLevel : MonoBehaviour
{
    // Make sure the player has the tag "Player" in your game.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Loads the next scene in the build order
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        // Get the current active scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene in the build order
        // Make sure to set up the scene order in Build Settings (File -> Build Settings)
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
