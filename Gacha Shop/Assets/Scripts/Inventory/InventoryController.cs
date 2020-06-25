using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    private ItemDatabase itemdatabase;
    public List<Item> playerItems = new List<Item>();
    public InventoryUIDetails inventoryDetailsPanel;
    // public InventoryUI inventoryUI;

    public static InventoryController Instance { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        itemdatabase = ItemDatabase.Instance;

        if(Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
            
        GiveItem("common_egg");
        GiveItem("common_wood");
    }

    public void GiveItem(string itemSlug){
        Item item = itemdatabase.GetItem(itemSlug);
        playerItems.Add(item);
        Debug.Log(playerItems.Count + " items in inventory. Added: " + itemSlug);
        UIEventHandler.ItemAddedToInventory(item);
    }

    public void SetItemDetails(Item item, Button selectedButton){
        inventoryDetailsPanel.SetItem(item, selectedButton);
    }
}