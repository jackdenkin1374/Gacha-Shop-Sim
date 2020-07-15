using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    public RectTransform inventoryPanel;
    public RectTransform scrollViewContent;
    InventoryUIItem itemContainer { get; set; }
    bool menuIsActive { get; set; }
    Item currentSelectedItem { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("InventoryUI Starting");
        UIEventHandler.OnItemAddedToInventory += ItemAdded;
        
        itemContainer = Resources.Load<InventoryUIItem>("UI/Container_Styles/Item_Container");
        inventoryPanel.gameObject.SetActive(false);
    }

    // void OnEnable() {
    //     UIEventHandler.OnItemAddedToInventory += ItemAdded;
    // }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            menuIsActive = !menuIsActive;
            inventoryPanel.gameObject.SetActive(menuIsActive);
        }
    }


    public void ItemAdded(Item item){
        Debug.Log("Adding Item: " + item.ItemName);
        InventoryUIItem emptyItem = Instantiate(itemContainer);
        emptyItem.SetItem(item);
        emptyItem.transform.SetParent(scrollViewContent);
    }
}
