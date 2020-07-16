using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectionUIItem : MonoBehaviour
{
    public Item item { get; set; }
    public TextMeshProUGUI itemText;
    public TextMeshProUGUI itemCount;
    public Image itemImage;

    public void SetItem(Item item){
        this.item = item;
        SetupItemValues();
    }

    private void SetupItemValues(){        
        itemText.SetText(item.ItemName);
        itemCount.SetText(item.ItemCount.ToString());
        itemImage.sprite = Resources.Load<Sprite>("UI/Icons/" + item.RarityType + "/" + item.ObjectSlug);
    }

    public void UpdateValues(){
        itemCount.SetText(item.ItemCount.ToString());
    }

    public void OnSelectItemButton(){
        InventoryController.Instance.SetItemDetails(item, GetComponent<Button>());
    }
}
