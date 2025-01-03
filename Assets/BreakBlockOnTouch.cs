using UnityEngine;

public class BreakBlockOnTouch : MonoBehaviour
{
    public string breakableTag = "BreakableBlock"; // Tag for breakable blocks
    private FormSwitcher formSwitcher; // Reference to the FormSwitcher script

    void Start()
    {
        // Get the FormSwitcher component from the player
        formSwitcher = GetComponent<FormSwitcher>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object touched has the specified tag
        if (other.CompareTag(breakableTag))
        {
            // Only destroy the block if the player is in Earth form
            if (formSwitcher != null && formSwitcher.IsEarthForm())
            {
                Destroy(other.gameObject);
                Debug.Log("Block destroyed in Earth form!");
            }
            else
            {
                Debug.Log("Cannot destroy block in Default form!");
            }
        }
    }
}
