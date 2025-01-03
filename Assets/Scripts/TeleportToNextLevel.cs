using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToNextLevel : MonoBehaviour
{
    // Trigger function when another collider (the player) enters this object's trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Load the next scene in the build order
            LoadNextLevel();
        }
    }

    // Loads the next scene in the build order
    private void LoadNextLevel()
    {
        // Get the current active scene's build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene in the build order (currentSceneIndex + 1)
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
