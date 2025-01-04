using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            Debug.Log("Diamond collected by player!");
            playerInventory.DiamondCollected();
            gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("PlayerInventory component not found on colliding object.");
        }
    }
}
