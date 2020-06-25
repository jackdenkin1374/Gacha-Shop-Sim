using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Item
{
    public enum ItemTypes { FoodAndDrink, Material }
    public enum RarityTypes { Common, Uncommon, Rare, Legendary}
    public string ObjectSlug { get; set; }
    public string ItemName { get; set; }
    public string Description { get; set; }
    
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public ItemTypes ItemType { get; set; }
    
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public RarityTypes RarityType { get; set; }
    public int Rarity { get; set; }

    [Newtonsoft.Json.JsonConstructor]
    public Item(string _objectSlug, string _itemName, string _description, ItemTypes _itemType, RarityTypes _rarityType, int _rarity)
    {
        this.ObjectSlug = _objectSlug;
        this.ItemName = _itemName;
        this.Description = _description;
        this.ItemType = _itemType;
        this.RarityType = _rarityType;
        this.Rarity = _rarity;
    }
}
