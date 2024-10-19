using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider lava)
    {
        if (lava.CompareTag("Player"))
        {
            // Save the current scene index to PlayerPrefs
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("LastLevel", currentSceneIndex);

            // Load the LoseScreen scene
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
