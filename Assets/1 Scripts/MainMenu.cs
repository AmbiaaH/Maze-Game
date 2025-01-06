using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1); // Load scene with build index 1
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit the application
    }

    public void LoadInformation()
    {
        SceneManager.LoadScene("Information"); // Load the scene named "Information"
    }
}
