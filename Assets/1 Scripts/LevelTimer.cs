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
        
    }
}
