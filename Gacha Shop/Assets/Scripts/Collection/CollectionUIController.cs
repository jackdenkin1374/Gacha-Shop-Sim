using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionUIController : MonoBehaviour
{
    public static CollectionUIController Instance { get; set; }
    public RectTransform inventoryPanel;
    public RectTransform scrollViewContent;
    public CollectionUIDetails inventoryDetailsPanel;
    CollectionUIItem itemContainer { get; set; }
    CollectionUIItem emptyItem;
    List<CollectionUIItem> activeItems = new List<CollectionUIItem>();
    bool menuIsActive { get; set; }
    Item currentSelectedItem { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
            
        UIEventHandler.OnItemAddedToInventoryOrCount += ItemAddOrUpdate;
        
        itemContainer = Resources.Load<CollectionUIItem>("UI/Container_Styles/Collection_Container");
    }

    public void ItemAddOrUpdate(Item item, bool toCount, bool isEmpty){
        foreach(var UIItem in activeItems){
            if(UIItem.item.ObjectSlug == item.ObjectSlug){
                emptyItem = UIItem;
                break;
            }
        }

        if(isEmpty){
            Debug.Log("Destroying " + item.ItemName + " item container");
            Destroy(emptyItem.gameObject);
            activeItems.Remove(emptyItem);
            inventoryDetailsPanel.gameObject.SetActive(false);
        } else {
            if(toCount){
                Debug.Log(emptyItem.item.ObjectSlug);
                emptyItem.UpdateValues();
            } else {
                Debug.Log("Adding Item: " + item.ItemName);
                emptyItem = Instantiate(itemContainer);
                activeItems.Add(emptyItem);
                emptyItem.SetItem(item);
                emptyItem.transform.SetParent(scrollViewContent, false);
            }
        }
    }

    public void SetItemDetails(Item item){
        Debug.Log("Setting up details");
        inventoryDetailsPanel.SetItem(item);
    }
}
