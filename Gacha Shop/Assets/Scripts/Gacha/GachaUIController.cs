using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaUIController : MonoBehaviour
{
    public RectTransform gachaPullPanel;
    public RectTransform scrollViewContent;
    GachaUIItem itemContainer { get; set; }
    GachaUIItem emptyItem;
    List<GachaUIItem> list = new List<GachaUIItem>();
    bool menuIsActive { get; set; }
    Item currentSelectedItem { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("GachaUI Starting");
        UIEventHandler.OnItemPulled += ItemPulled;
        
        itemContainer = Resources.Load<GachaUIItem>("UI/Container_Styles/Gacha_Pull_Container");
        gachaPullPanel.gameObject.SetActive(false);
    }

    public void ItemPulled(Item item){
        Debug.Log("Pulling Item: " + item.ItemName);
        emptyItem = Instantiate(itemContainer);
        list.Add(emptyItem);
        emptyItem.SetItem(item);
        emptyItem.transform.SetParent(scrollViewContent);
    }

    public void DestroyItemPulled(){
        foreach(var item in list){
            Destroy(item.gameObject);
        }
        list.Clear();
    }

    public void ClearPanel(){
        DestroyItemPulled();
        gachaPullPanel.gameObject.SetActive(false);
    }
}
