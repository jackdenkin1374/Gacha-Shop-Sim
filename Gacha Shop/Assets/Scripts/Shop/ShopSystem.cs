using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    public static ShopSystem Instance { get; set; }
    public Item item;
    private ItemDatabase itemdatabase;
    private InventoryController inventory;
    private PlayerSystem playersystem;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
            
        itemdatabase = ItemDatabase.Instance;
        inventory = InventoryController.Instance;
        playersystem = PlayerSystem.Instance;
    }

    public void sell(Item item, ShopUIItem UIitem, int count){
        Debug.Log("Selling " + count + item.ItemName);
        int counter = 0;
        while(counter < count){
            inventory.RemoveItem(item.ObjectSlug);
            playersystem.ChangeMoney((int) item.MonetaryValue, true);
            counter++;
        }
        UIitem.UpdateValues();
    }

    public void sellAll(Item item, ShopUIItem UIitem){
        Debug.Log("Selling all " + item.ItemName);
        double count = item.ItemCount;
        double counter = 0;
        while(counter < count){
            inventory.RemoveItem(item.ObjectSlug);
            playersystem.ChangeMoney((int) item.MonetaryValue, true);
            counter++;
        }
        UIitem.UpdateValues();
    }
}
