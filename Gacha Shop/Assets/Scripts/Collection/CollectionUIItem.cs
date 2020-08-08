using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CollectionUIItem : MonoBehaviour
{
    public Item item { get; set; }
    public TextMeshProUGUI itemText;
    public TextMeshProUGUI itemCount;
    public Image itemImage;
    private CollectionUIController collectionUIController;

    void Start()
    {
        collectionUIController = CollectionUIController.Instance;
        Debug.Log("collection UI Controller is ");
        Debug.Log(collectionUIController);
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
    }

    public void SetUpItemDetails(){
        // Debug.Log("item is "+ item.ItemName);
        // Debug.Log(collectionUIController);
        collectionUIController.SetItemDetails(item);
    } 
}
