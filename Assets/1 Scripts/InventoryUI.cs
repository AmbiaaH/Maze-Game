using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Using TextMeshPro for advanced text rendering

public class InventoryUI : MonoBehaviour
{
    // Reference to the TextMeshProUGUI component that will display the number of diamonds
    private TextMeshProUGUI diamondText;

    // Called when the script is initialized
    void Start()
    {
        // Get the TextMeshProUGUI component from the same GameObject
        diamondText = GetComponent<TextMeshProUGUI>();
    }

    // Public method to update the diamond text on the UI
    // Takes the player's inventory and the total number of diamonds as input
    public void UpdateDiamondText(PlayerInventory playerInventory, int totalDiamonds)
    {
        // Update the text to display current collected diamonds / total diamonds
        diamondText.text = playerInventory.NumberOfDiamonds.ToString() + " / " + totalDiamonds.ToString();
    }
}