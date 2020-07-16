using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    private ItemDatabase itemdatabase;
    public List<Item> playerItems = new List<Item>();
    // public List<Item> playerItemstest = new List<Item>();
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            GiveItem("common_egg");
        }
    }

    public void GiveItem(string itemSlug){
        Item item = itemdatabase.GetItem(itemSlug);
        // playerItems.Add(item);
        // Debug.Log(playerItems.Count + " items in inventory. Added: " + itemSlug);
        // UIEventHandler.ItemAddedToInventory(item);

        if(!playerItems.Contains(item) && item.ItemCount == 0){
            playerItems.Add(item);
            Debug.Log(playerItems.Count + " items in inventory. Added: " + itemSlug);
            item.ItemCount++;
            UIEventHandler.ItemAddedToInventory(item);
            UIEventHandler.ItemAddedToInventoryOrCount(item, false);
        } else {          
            item.ItemCount++;
            Debug.Log(item.ObjectSlug + " Count is : " + item.ItemCount);
            UIEventHandler.ItemAddedToInventoryOrCount(item, true);
        }
    }

    public void SetItemDetails(Item item, Button selectedButton){
        inventoryDetailsPanel.SetItem(item, selectedButton);
    }
}