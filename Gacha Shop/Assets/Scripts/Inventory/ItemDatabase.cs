using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance { get; set; }
    public List<Item> Items { get; set; }
    // public List<Item> rarityList = new List<Item>();

    // public List<Item> common = new List<Item>();
    // public List<Item> uncommon = new List<Item>();
    // public List<Item> rare = new List<Item>();
    // public List<Item> legendary = new List<Item>();

    public List<GachaPass> listOfGachas = new List<GachaPass>();
    public GachaPass Beginner_Pool = new GachaPass("Beginner_Pool", "Beginner's Pool");
    public GachaPass Deserted_Town = new GachaPass("Deserted_Town", "Deserted Town");
    public GachaPass Forge = new GachaPass("Forge", "Forge");
    public GachaPass Once_In_A_Lifetime = new GachaPass("Once_In_A_Lifetime", "Once In A Lifetime");

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;    
        BuildDatabase();
    }

    private void BuildDatabase()
    {
        Items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("JSON/Items").ToString());

        // foreach(Item item in Items){
        //     if(item.RarityType.ToString() == "Common")
        //         common.Add(item);
        //     if(item.RarityType.ToString() == "Uncommon")
        //         uncommon.Add(item);
        //     if(item.RarityType.ToString() == "Rare")
        //         rare.Add(item);
        //     if(item.RarityType.ToString() == "Legendary")
        //         legendary.Add(item);
        // }

        foreach(Item item in Items){
            int count = item.GachaType.Length;
            for(int i = 0; i<count; i++){
                buildRarityList(i, Beginner_Pool, item);
                buildRarityList(i, Deserted_Town, item);
                buildRarityList(i, Forge, item);
                buildRarityList(i, Once_In_A_Lifetime, item);  
            }
        }

        listOfGachas.Add(Beginner_Pool);
        listOfGachas.Add(Deserted_Town);
        listOfGachas.Add(Forge);
        listOfGachas.Add(Once_In_A_Lifetime);

        
        // Debug.Log(Beginner_Pool.name + " Common count is " + Beginner_Pool.common.Count);
        // Debug.Log("Beginner Pool Uncommon count is " + Beginner_Pool.uncommon.Count);
        // Debug.Log("Beginner Pool Rare count is " + Beginner_Pool.rare.Count);
        // Debug.Log("Beginner Pool Legendary count is " + Beginner_Pool.legendary.Count);

        // Debug.Log("Deserted Town Common count is " + Deserted_Town.common.Count);
        // Debug.Log("Deserted Town Uncommon count is " + Deserted_Town.uncommon.Count);
        // Debug.Log("Deserted Town Rare count is " + Deserted_Town.rare.Count);
        // Debug.Log("Deserted Town Legendary count is " + Deserted_Town.legendary.Count);

        // Debug.Log("Forge Common count is " + Forge.common.Count);
        // Debug.Log("Forge Uncommon count is " + Forge.uncommon.Count);
        // Debug.Log("Forge Rare count is " + Forge.rare.Count);
        // Debug.Log("Forge Legendary count is " + Forge.legendary.Count);

        // Debug.Log("Lifetime Common count is " + Once_In_A_Lifetime.common.Count);
        // Debug.Log("Lifetime Uncommon count is " + Once_In_A_Lifetime.uncommon.Count);
        // Debug.Log("Lifetime Rare count is " + Once_In_A_Lifetime.rare.Count);
        // Debug.Log("Lifetime Legendary count is " + Once_In_A_Lifetime.legendary.Count);

        // Debug.Log(listOfGachas.Count);
        // Debug.Log(listOfGachas[0].common.Count);
    }

    private void buildRarityList(int index, GachaPass pass, Item item){
        if(item.GachaType[index].ToString() == pass.objectSlug){
            switch(item.RarityType.ToString()){
                case "Common":
                    pass.common.Add(item);
                    break;
                case "Uncommon":
                    pass.uncommon.Add(item);
                    break;
                case "Rare":
                    pass.rare.Add(item);
                    break;
                case "Legendary":
                    pass.legendary.Add(item);
                    break;
            }
        }
    }

    public Item GetItem(string itemSlug){
        foreach(Item item in Items){
            if(item.ObjectSlug == itemSlug)
                return item;
        }
        Debug.LogWarning("Couldn't find item: " + itemSlug);
        return null;
    }
}