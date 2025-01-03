using UnityEngine;

public class FormSwitcher : MonoBehaviour
{
    public enum CharacterForm { Default, Earth } // Define character forms
    public CharacterForm currentForm = CharacterForm.Default; // Start in Default form

    public GameObject earthIndicator; // Assign the Earth indicator (e.g., a sphere) in the Inspector

    void Update()
    {
        // Switch to Earth form when "H" is pressed
        if (Input.GetKeyDown(KeyCode.H))
        {
            currentForm = CharacterForm.Earth;
            ActivateEarthIndicator(true);
            Debug.Log("Switched to Earth form");
        }

        // Switch back to Default form when "G" is pressed
        if (Input.GetKeyDown(KeyCode.G))
        {
            currentForm = CharacterForm.Default;
            ActivateEarthIndicator(false);
            Debug.Log("Switched to Default form");
        }
    }

    void ActivateEarthIndicator(bool isActive)
    {
        if (earthIndicator != null)
        {
            earthIndicator.SetActive(isActive);
        }
    }

    public bool IsEarthForm()
    {
        return currentForm == CharacterForm.Earth;
    }
}
