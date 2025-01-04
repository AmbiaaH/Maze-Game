using UnityEngine;
using UnityEngine.SceneManagement; // Required for SceneManager

public class TeleportToNextScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player touches the plane
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched the plane. Attempting to load the next scene...");
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Calculate the next scene index
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if the next scene index is valid
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene
            Debug.Log("Loading scene with index: " + nextSceneIndex);
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No more scenes to load. This is the last scene.");
        }
    }
}
