using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    // OnTriggerEnter is called when the player collides with this object (a diamond)
    private void OnTriggerEnter(Collider other)
    {
        // Get the PlayerInventory component from the colliding object (the player)
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        // If the colliding object has a PlayerInventory component (i.e., it's the player)
        if (playerInventory != null)
        {
            // Call the method to increment the player's diamond count
            playerInventory.DiamondCollected();

            // Deactivate the diamond (so it disappears after being collected)
            gameObject.SetActive(false);

            // Assuming you have a reference to your InventoryUI
            // Finds the InventoryUI object in the scene to update the UI
            InventoryUI inventoryUI = FindObjectOfType<InventoryUI>();

            // Update the UI with the player's current diamonds and the total diamonds (in this example, 4)
            inventoryUI.UpdateDiamondText(playerInventory, 4); // Assuming there are 4 diamonds in total
        }
    }
}
