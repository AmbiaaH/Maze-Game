using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfDiamonds { get; private set; }
    public UnityEvent<PlayerInventory> OnDiamondCollected = new UnityEvent<PlayerInventory>();

    void Start()
    {
        OnDiamondCollected.AddListener(UpdateInventoryUI);
    }

    public void DiamondCollected()
    {
        NumberOfDiamonds++;
        Debug.Log("Diamond collected! Current count: " + NumberOfDiamonds);
        OnDiamondCollected.Invoke(this);
    }

    private void UpdateInventoryUI(PlayerInventory playerInventory)
    {
        InventoryUI inventoryUI = FindObjectOfType<InventoryUI>();
        if (inventoryUI != null)
        {
            Debug.Log("Updating Inventory UI.");
            inventoryUI.UpdateDiamondText(playerInventory, 4); // Total diamonds hardcoded as 4 for now
        }
        else
        {
            Debug.LogWarning("InventoryUI not found in the scene.");
        }
    }
}
