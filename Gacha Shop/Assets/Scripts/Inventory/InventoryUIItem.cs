using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUIItem : MonoBehaviour
{
    public Item item;
    public TextMeshProUGUI itemText;

    public void SetItem(Item item){
        this.item = item;
        SetupItemValues();
    }

    private void SetupItemValues(){
        itemText.SetText(item.ItemName);
    }

    public void OnSelectItemButton(){
        InventoryController.Instance.SetItemDetails(item, GetComponent<Button>());
    }
}
