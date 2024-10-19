using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI diamondText;

    void Start()
    {
        diamondText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateDiamondText(PlayerInventory playerInventory, int totalDiamonds)
    {
        diamondText.text = playerInventory.NumberOfDiamonds.ToString() + " / " + totalDiamonds.ToString();
    }
}