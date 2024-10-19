using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.DiamondCollected();
            gameObject.SetActive(false);

            // Assuming you have a reference to your InventoryUI
            InventoryUI inventoryUI = FindObjectOfType<InventoryUI>();
            inventoryUI.UpdateDiamondText(playerInventory, 4); // Assuming there are 4 diamonds in total
        }
    }

}
