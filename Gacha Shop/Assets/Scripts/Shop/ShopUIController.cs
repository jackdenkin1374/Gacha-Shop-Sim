using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIController : MonoBehaviour
{
    public static ShopUIController Instance { get; set; }
    public RectTransform inventoryPanel;
    public RectTransform scrollViewContent;
    ShopUIItem itemContainer { get; set; }
    ShopUIItem emptyItem;
    List<ShopUIItem> activeItems = new List<ShopUIItem>();
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
        
        itemContainer = Resources.Load<ShopUIItem>("UI/Container_Styles/Shop_Container");
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
}
