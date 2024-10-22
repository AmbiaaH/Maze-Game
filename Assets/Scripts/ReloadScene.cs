using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    // OnTriggerEnter is called when another object enters the collider of the attached object
    private void OnTriggerEnter(Collider lava)
    {
        // Check if the colliding object has the tag "Player"
        if (lava.CompareTag("Player"))
        {
            // Save the current scene index to PlayerPrefs to reload later
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("LastLevel", currentSceneIndex);

            // Load the LoseScreen scene
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
