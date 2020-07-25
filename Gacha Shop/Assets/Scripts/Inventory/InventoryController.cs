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
        if (Input.GetKeyDown(KeyCode.L)){
            GiveItem("common_egg");
        } else if(Input.GetKeyDown(KeyCode.K)){
            RemoveItem("common_egg");
        } else if(Input.GetKeyDown(KeyCode.J)){
            RemoveItem("common_wood");
        }
    }

    public void GiveItem(string itemSlug){
        Item item = itemdatabase.GetItem(itemSlug);
        Debug.Log("Adding " + itemSlug + " -----------------------");

        if(!playerItems.Contains(item) && item.ItemCount == 0){
            playerItems.Add(item);
            Debug.Log(playerItems.Count + " items in inventory. Added: " + itemSlug);
            item.ItemCount++;
            // UIEventHandler.ItemAddedToInventory(item); // Old Panel Inventory Test
            UIEventHandler.ItemAddedToInventoryOrCount(item, false, false); // Doesn't count, adds the item container
        } else {          
            item.ItemCount++;
            // Debug.Log(playerItems.Count + " items in inventory. Added: " + itemSlug);
            Debug.Log(item.ObjectSlug + " Count is : " + item.ItemCount);
            UIEventHandler.ItemAddedToInventoryOrCount(item, true, false); // Counts and update it via the UI
        }
    }

    public void RemoveItem(string itemSlug){
        Item item = itemdatabase.GetItem(itemSlug);

        if(playerItems.Contains(item)){
            Debug.Log("Removing " + itemSlug + " -----------------------");

            item.ItemCount--;
            Debug.Log(item.ObjectSlug + " Count is : " + item.ItemCount);
            UIEventHandler.ItemAddedToInventoryOrCount(item, true, false);

            if(item.ItemCount == 0){
                playerItems.Remove(item);
                Debug.Log(playerItems.Count + " items in inventory. Removed: " + itemSlug);
                UIEventHandler.ItemAddedToInventoryOrCount(item, false, true);
            }
        } else {
            Debug.Log("playerItems does not have " + item.ItemName);
        }
    }

    public void SetItemDetails(Item item, Button selectedButton){
        inventoryDetailsPanel.SetItem(item, selectedButton);
    }
}