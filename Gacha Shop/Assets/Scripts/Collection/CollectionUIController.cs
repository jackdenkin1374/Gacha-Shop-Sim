using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionUIController : MonoBehaviour
{
    public RectTransform inventoryPanel;
    public RectTransform scrollViewContent;
    CollectionUIItem itemContainer { get; set; }
    CollectionUIItem emptyItem;
    List<CollectionUIItem> activeItems = new List<CollectionUIItem>();
    bool menuIsActive { get; set; }
    Item currentSelectedItem { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        UIEventHandler.OnItemAddedToInventoryOrCount += ItemAddOrUpdate;
        
        itemContainer = Resources.Load<CollectionUIItem>("UI/Container_Styles/Collection_Container");
    }

    public void ItemAdded(Item item){
        Debug.Log("Adding Item: " + item.ItemName);
        emptyItem = Instantiate(itemContainer);
        activeItems.Add(emptyItem);
        emptyItem.SetItem(item);
        emptyItem.transform.SetParent(scrollViewContent);
    }

    public void ItemAddOrUpdate(Item item, bool toCount){
        if(toCount){
            foreach(var UIItem in activeItems){
                if(UIItem.item.ObjectSlug == item.ObjectSlug){
                    emptyItem = UIItem;
                    break;
                }
            }
            Debug.Log(emptyItem.item.ObjectSlug);
            emptyItem.UpdateValues();
        } else {
            Debug.Log("Adding Item: " + item.ItemName);
            emptyItem = Instantiate(itemContainer);
            activeItems.Add(emptyItem);
            emptyItem.SetItem(item);
            emptyItem.transform.SetParent(scrollViewContent);
        }
    }
}
