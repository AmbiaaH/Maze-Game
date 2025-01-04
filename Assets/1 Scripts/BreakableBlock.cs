using UnityEngine;

public class BreakableBlock : MonoBehaviour
{
    public FormSwitcher formSwitcher; // Reference to the FormSwitcher script
    private BoxCollider boxCollider; // Reference to the block's BoxCollider

    void Start()
    {
        // Get the BoxCollider component
        boxCollider = GetComponent<BoxCollider>();

        if (boxCollider == null)
        {
            Debug.LogError("No BoxCollider attached to the BreakableBlock!");
        }
    }

    private void Update()
    {
        // Toggle the "Is Trigger" property based on the player's form
        if (formSwitcher != null)
        {
            if (formSwitcher.IsEarthForm())
            {
                boxCollider.isTrigger = true; // Allow the player to destroy the block
            }
            else
            {
                boxCollider.isTrigger = false; // Make the block solid
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name); // Log the triggering object

        if (other.CompareTag("Player"))
        {
            // Check if the Earth form is active
            if (formSwitcher != null && formSwitcher.IsEarthForm())
            {
                Debug.Log("Earth form is active. Destroying block...");
                gameObject.SetActive(false); // Destroy the block
            }
            else
            {
                Debug.Log("Earth form is not active. Block cannot be destroyed.");
            }
        }
    }
}
