using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CollectionUIItem : MonoBehaviour
// public class CollectionUIItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Item item { get; set; }
    public TextMeshProUGUI itemText;
    public TextMeshProUGUI itemCount;
    public Image itemImage;
    private CollectionUIController collectionUIController;
    // public CollectionUIDetails itemDetails;
    // public Image background;

    void Start()
    {
        collectionUIController = CollectionUIController.Instance;
        Debug.Log("collection UI Controller is ");
        Debug.Log(collectionUIController);
        // background = GetComponent<Image>();
        // collectionUIGroup.Subscribe(this);
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

    // public void OnSelectItemButton(){
    //     InventoryController.Instance.SetItemDetails(item, GetComponent<Button>());
    // }

    public void SetUpItemDetails(){
        Debug.Log("item is "+ item.ItemName);
        Debug.Log(collectionUIController);
        collectionUIController.SetItemDetails(item);
    }

    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     collectionUIGroup.OnTabSelected(this);
    // }

    // public void OnPointerEnter(PointerEventData eventData)
    // {
    //     collectionUIGroup.OnTabEnter(this);
    // }

    // public void OnPointerExit(PointerEventData eventData)
    // {
    //     collectionUIGroup.OnTabExit(this);
    // }    
}
