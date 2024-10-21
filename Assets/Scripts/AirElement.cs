using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirElement : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject airElementIndicator;

    public float newJumpPower = 21f;
    public float newWalkSpeed = 75f;
    public float newRunSpeed = 150f;

    private float oldJumpPower = 7f;
    private float oldWalkSpeed = 6f;
    private float oldRunSpeed = 12f;

    private bool isTriggered = false; 

    void Start()
    {
        if (playerMovement == null)
        {
            playerMovement = GetComponent<PlayerMovement>();
        }
    }

    void Update()
    {
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

    public void BackupOldValues()
    {
        oldJumpPower = playerMovement.jumpPower;
        oldWalkSpeed = playerMovement.def_walk_speed;
        oldRunSpeed = playerMovement.def_run_speed;
    }
}
