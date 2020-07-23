using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUIDetails : MonoBehaviour
{
    private Item item;
    public Button selectedItemButton, itemInteractButton;
    public TextMeshProUGUI  itemNameText, itemDescriptionText, itemInteractButtonText; 

    void Start() {
        // itemNameText = transform.Find("Item_Name").GetComponent<TextMeshProUGUI >();
        // itemDescriptionText = transform.Find("Item_Description").GetComponent<TextMeshProUGUI >();
        // itemInteractButton = transform.GetComponentInChildren<Button>();
        // itemInteractButtonText = itemInteractButton.GetComponentInChildren<TextMeshProUGUI>();
        gameObject.SetActive(false);
    }

    public void SetItem(Item item, Button selectedButton){
        gameObject.SetActive(true);
        this.item = item;
        selectedItemButton = selectedButton;
        itemNameText.text = item.ItemName;
        itemDescriptionText.text = item.Description;
    }
}
