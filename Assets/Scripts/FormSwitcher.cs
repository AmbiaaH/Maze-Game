using UnityEngine;

public class FormSwitcher : MonoBehaviour
{
    public enum CharacterForm { Default, Earth } // Define forms
    public CharacterForm currentForm = CharacterForm.Default; // Start in Default form

    public GameObject earthIndicator; // Reference to the Earth indicator (e.g., a sphere above the player)

    void Update()
    {
        // Toggle Earth form when "K" is pressed
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (currentForm == CharacterForm.Default)
            {
                currentForm = CharacterForm.Earth;
                ActivateEarthIndicator(true);
                Debug.Log("Switched to Earth form");
            }
            else if (currentForm == CharacterForm.Earth)
            {
                currentForm = CharacterForm.Default;
                ActivateEarthIndicator(false);
                Debug.Log("Switched to Default form");
            }
        }
    }

    void ActivateEarthIndicator(bool isActive)
    {
        if (earthIndicator != null)
        {
            earthIndicator.SetActive(isActive); // Show or hide the Earth indicator
        }
    }

    public bool IsEarthForm()
    {
        return currentForm == CharacterForm.Earth; // Return true if in Earth form
    }
}
