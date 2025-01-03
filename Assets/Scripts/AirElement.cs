using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirElement : MonoBehaviour
{
    public PlayerMovement playerMovement;     // Reference to the PlayerMovement script
    public GameObject airElementIndicator;    // Indicator for the air element effect in the game

    
    // New player stats for air element effect
    public float newJumpPower = 21f;
    public float newWalkSpeed = 50f;
    public float newRunSpeed = 100f;
    
    // Original player stats to revert back to
    private float oldJumpPower = 7f;
    private float oldWalkSpeed = 6f;
    private float oldRunSpeed = 12f;
    
    // State variable to track if the air element is activated
    private bool isTriggered = false; 

    void Start()
    {
            // Get the PlayerMovement component if not already assigned
        if (playerMovement == null)
        {
            playerMovement = GetComponent<PlayerMovement>();
        }
    }

    void Update()
    {
         // Toggle the air element effect when the CapsLock key is pressed
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            if (!isTriggered)
            {
                airElementIndicator.SetActive(true);
                UpdateNewPlayerStats();
                isTriggered = true;
            }
            else
            {
                airElementIndicator.SetActive(false);
                UpdateOldPlayerStats();
                isTriggered = false;
            }
        }
    }
    
    // Method to update the player's stats to the new air element values
    public void UpdateNewPlayerStats()
    {
        if (playerMovement != null)
        {
            BackupOldValues();
            playerMovement.jumpPower = newJumpPower;
            playerMovement.def_walk_speed = newWalkSpeed;
            playerMovement.def_run_speed = newRunSpeed;

            Debug.Log("Player stats updated: JumpPower = " + newJumpPower +
                      ", WalkSpeed = " + newWalkSpeed + ", RunSpeed = " + newRunSpeed);
        }
    }
    
    // Method to revert the player's stats to the old values
    public void UpdateOldPlayerStats()
    {
        if (playerMovement != null)
        {
            playerMovement.jumpPower = oldJumpPower;
            playerMovement.def_walk_speed = oldWalkSpeed;
            playerMovement.def_run_speed = oldRunSpeed;

            Debug.Log("Player stats updated: JumpPower = " + oldJumpPower +
                      ", WalkSpeed = " + oldWalkSpeed + ", RunSpeed = " + oldRunSpeed);        
        }
    }
    
    // Method to back up the current player stats
    public void BackupOldValues()
    {
        oldJumpPower = playerMovement.jumpPower;
        oldWalkSpeed = playerMovement.def_walk_speed;
        oldRunSpeed = playerMovement.def_run_speed;
    }
}
