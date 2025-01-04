using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText; // Assign the Text element from the Canvas
    private float elapsedTime = 0f;
    private bool isRunning = false;

    // Start the timer
    public void StartTimer()
    {
        isRunning = true;
    }

    // Stop the timer
    public void StopTimer()
    {
        isRunning = false;
    }

    // Reset the timer
    public void ResetTimer()
    {
        elapsedTime = 0f;
        UpdateTimerText();
    }

    private void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerText();
        }
    }

    // Update the UI Text with formatted time
    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(elapsedTime / 60F);
            int seconds = Mathf.FloorToInt(elapsedTime % 60F);
            int milliseconds = Mathf.FloorToInt((elapsedTime * 100F) % 100F);
            timerText.text = $"{minutes:00}:{seconds:00}:{milliseconds:00}";
        }
    }
}
