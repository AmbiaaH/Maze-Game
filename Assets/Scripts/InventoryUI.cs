using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI diamondText;

    public void UpdateDiamondText(PlayerInventory playerInventory, int totalDiamonds)
    {
        if (diamondText != null)
        {
            Debug.Log($"Updating diamond text: {playerInventory.NumberOfDiamonds} / {totalDiamonds}");
            diamondText.text = $"{playerInventory.NumberOfDiamonds} / {totalDiamonds}";
        }
        else
        {
            Debug.LogError("DiamondText reference is missing in the InventoryUI script!");
        }
    }
}
