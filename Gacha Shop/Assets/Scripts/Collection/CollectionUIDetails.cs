using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectionUIDetails : MonoBehaviour
{
    private Item item;
    public TextMeshProUGUI itemDescriptionText, itemRarity, itemPrice;

    void Start() {
        gameObject.SetActive(false);
    }

    public void SetItem(Item item){
        gameObject.SetActive(true);
        this.item = item;
        itemDescriptionText.text = item.Description;
        itemRarity.text = "Rarity: " + item.RarityType.ToString();
        itemPrice.text = "Selling Price: " + item.MonetaryValue.ToString();
    }
}
