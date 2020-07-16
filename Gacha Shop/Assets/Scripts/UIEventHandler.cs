using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour
{
    public delegate void ItemEventHandler(Item item);
    public static event ItemEventHandler OnItemAddedToInventory;
    public static event ItemEventHandler OnItemPulled;

    public delegate void ItemCountEventHandler(Item item, bool toCount);
    public static event ItemCountEventHandler OnItemAddedToInventoryOrCount;

    public static void ItemAddedToInventory(Item item){
        if (OnItemAddedToInventory != null)
            OnItemAddedToInventory(item);
    }

    public static void ItemPulled(Item item){
        if (OnItemPulled != null)
            OnItemPulled(item);
    }

    // toCount - true is to update count
    // false is to add item to UI
    public static void ItemAddedToInventoryOrCount(Item item, bool toCount){
        if (OnItemAddedToInventoryOrCount != null && toCount) // to count item
            OnItemAddedToInventoryOrCount(item, toCount);
        else if (OnItemAddedToInventoryOrCount != null && !toCount) // to add item to UI
            OnItemAddedToInventoryOrCount(item, toCount);
    }
}
