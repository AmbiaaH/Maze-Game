using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;  // For UnityEvent

public class PlayerInventory : MonoBehaviour
{
    // Public property to store the number of diamonds the player has collected
    // Private setter ensures only the PlayerInventory class can modify this value
    public int NumberOfDiamonds { get; private set; }

    // Event that will be triggered when the player collects a diamond
    // Other classes can subscribe to this event to react when a diamond is collected
    public UnityEvent<PlayerInventory> OnDiamondCollected;

    // Method that is called when the player collects a diamond
    public void DiamondCollected()
    {
        // Increment the number of diamonds the player has
        NumberOfDiamonds++;

        // Trigger the OnDiamondCollected event, passing this PlayerInventory instance
        OnDiamondCollected.Invoke(this);
    }
}
