using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float levelTime = 600f; // Total time for the level in seconds

    [Header("UI Elements")]
    public TMP_Text timerText; // Reference to the UI Text to display time

    [Header("Next Level Settings")]
    public SceneAsset nextLevel; // Name of the next scene to load

    private float timeRemaining;
    private bool timerRunning = false;

    void Start()
    {
        timeRemaining = levelTime;
        timerRunning = true;
        UpdateTimerText();
    }

    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                timeRemaining = 0;
                timerRunning = false;
                LevelComplete();
            }
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = "Time Left: " + timerText.text;
    }

    void LevelComplete()
    {
        // Load the next level
        if (nextLevel != null)
        {
            string scenePath = AssetDatabase.GetAssetPath(nextLevel);
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Next level name not set!");
        }
    }
}
