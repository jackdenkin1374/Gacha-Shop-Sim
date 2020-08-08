using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUIItem : MonoBehaviour
{
    public Item item { get; set; }
    public TextMeshProUGUI itemText;
    public TextMeshProUGUI itemCount;
    public Image itemImage;
    private ShopUIController shopUIController;
    private ShopSystem shop;

    public Button sell1;
    public Button sell10;
    public Button sell100;
    public Button sell1000;
    public Button sellAll;

    void Start()
    {
        shop = ShopSystem.Instance;
        shopUIController = ShopUIController.Instance;

        Debug.Log("--------IMPORTANT SHOP IS ");
        Debug.Log(shop);

        sell1.interactable = true;
        sell10.interactable = false;
        sell100.interactable = false;
        sell1000.interactable = false;
        sellAll.interactable = true;
        Debug.Log("shop UI Controller is ");
        Debug.Log(shopUIController);
    }

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
        sell10.interactable = false;
        sell100.interactable = false;
        sell1000.interactable = false;
        if(item.ItemCount > 0 && item.ItemCount < 10){
            sell1.interactable = true;           
            sellAll.interactable = true;
        }

        if(item.ItemCount >= 10 && item.ItemCount < 100){
            sell10.interactable = true;
        }

        if(item.ItemCount >= 100 && item.ItemCount < 1000){
            sell100.interactable = true;
        }

        if(item.ItemCount >= 1000){
            sell1000.interactable = true;
        }
    }

    public void sellItems(int count){
        Debug.Log(item.ItemName + " Sold");
        Debug.Log(shop);
        shop.sell(item, this, count);
    }

    public void sellAllItems(){
        shop.sellAll(item, this);
    }
}
