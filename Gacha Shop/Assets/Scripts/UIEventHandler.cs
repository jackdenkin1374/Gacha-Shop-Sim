using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour
{
    public delegate void ItemEventHandler(Item item);
    public static event ItemEventHandler OnItemAddedToInventory;
    public static event ItemEventHandler OnItemPulled;

    public static void ItemAddedToInventory(Item item){
        if (OnItemAddedToInventory != null)
            OnItemAddedToInventory(item);
    }

    public static void ItemPulled(Item item){
        if (OnItemPulled != null)
            OnItemPulled(item);
    }
}
