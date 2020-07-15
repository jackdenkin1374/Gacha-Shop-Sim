using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GachaUIItem : MonoBehaviour
{
    public Item item;
    public TextMeshProUGUI itemText;
    public Image itemImage;

    public void SetItem(Item item){
        this.item = item;
        SetupItemValues();
    }

    private void SetupItemValues(){        
        itemText.SetText(item.ItemName);
        itemImage.sprite = Resources.Load<Sprite>("UI/Icons/" + item.RarityType + "/" + item.ObjectSlug);
    }
}
