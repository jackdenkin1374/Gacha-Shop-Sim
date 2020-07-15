using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaSystem : MonoBehaviour
{
    public PlayerSystem ps;
    public RectTransform gachaPullPanel;
    // public GameObject contentView;
    public GachaUIController gachaUIController;

    private ItemDatabase itemdatabase;
    private InventoryController inventory;

    public List<Item> rarityList = new List<Item>();
    
    // public List<GameObject> items;
    public int[] rates = {
        550, //Common
        300, //Uncommon
        100, //Rare
        50 // Legendary
    };

    public List<Item> common = new List<Item>();
    public List<Item> uncommon = new List<Item>();
    public List<Item> rare = new List<Item>();
    public List<Item> legendary = new List<Item>();

    private int total;
    private int rand;

    private void Start(){
        itemdatabase = ItemDatabase.Instance;
        inventory = InventoryController.Instance;

        foreach(Item item in itemdatabase.Items){
            if(item.RarityType.ToString() == "Common")
                common.Add(item);
            if(item.RarityType.ToString() == "Uncommon")
                uncommon.Add(item);
            if(item.RarityType.ToString() == "Rare")
                rare.Add(item);
            if(item.RarityType.ToString() == "Legendary")
                legendary.Add(item);
        }

        Debug.Log(itemdatabase.Items[1].ItemName);
        Debug.Log(common[1].ItemName);
        Debug.Log(itemdatabase.Items[7].ItemName);
        Debug.Log(common[7].ItemName);

        Debug.Log("Items in common rarity list is: " + common.Count);
        Debug.Log("Items in uncommon rarity list is: " + uncommon.Count);
        Debug.Log("Items in rare rarity list is: " + rare.Count);
        Debug.Log("Items in legendary rarity list is: " + legendary.Count);
    }

    private void runGacha(int count){      
        for(int x = 0; x < count; x++){
            Debug.Log("Pulling " + (x+1));
            total = 0;

            foreach(var item in rates){
                total += item;
            }
            // Debug.Log("Total is " + total);
            rand = Random.Range(0, total);
            // Debug.Log("Rand is " + rand);

            foreach(var weight in rates){
                if(rand <= weight){
                    //award item
                    runRarity(weight);
                    break;
                } else {
                    rand -= weight;
                }
            }

            ps.money -= 100;
            // for(int i = 0; i < rates.Length; i++){
            //     if(rand < rates[i]){
            //         //award item
            //         Debug.Log("Award: " + weight);
            //         return;
            //     } else {
            //         rand -= rates[i];
            //     }
            // }
        }
        ps.TimesXButtonText();
        ps.CountMoney();
        Debug.Log(ps.money);
        Debug.Log("End of pull");
    }

    private Item runRarity(int rarityWeight){
        total = 0;
        
        switch(rarityWeight){
            case 550:
                Debug.Log("Common Pull");
                runRandAndList(common);
            break;

            case 300:
                Debug.Log("Uncommon Pull");
                runRandAndList(uncommon);
            break;

            case 100:
                Debug.Log("Rare Pull");
                runRandAndList(rare);
            break;

            case 50:
                Debug.Log("Legendary Pull");
                runRandAndList(legendary);
            break;
        }
        return null;
    }

    private Item runRandAndList(List<Item> list){
        total = 0;
        foreach(var item in list){
            total += item.Rarity;
        }
        rand = Random.Range(0, total);
        foreach(var itemWeight in list){
            if(rand <= itemWeight.Rarity){
                //award item
                Debug.Log("Award: " + itemWeight.ItemName + " - " + itemWeight.Rarity + " - " + itemWeight.RarityType);
                inventory.GiveItem(itemWeight.ObjectSlug);
                UIEventHandler.ItemPulled(itemWeight);
                return itemWeight;
            } else {
                rand -= itemWeight.Rarity;
            }
        }
        Debug.Log("Return Null");
        return null;
    }

    public void TimesOnePull(){
        if(gachaPullPanel.gameObject.activeSelf == false) {
            gachaPullPanel.gameObject.SetActive(true);
            runGacha(1);
        } else {
            gachaUIController.DestroyItemPulled();
            runGacha(1);
        }
    }

    public void TimesXPull(){
        int totalAmount = 1000;
        int lower;
        if(ps.money < 100){
            Debug.Log("Not enough money");
            return;
        }

        if(gachaPullPanel.gameObject.activeSelf == false){
            gachaPullPanel.gameObject.SetActive(true);
            if(ps.money > totalAmount){               
                runGacha((totalAmount/100));
                return;
            }

            while(true){
                lower = totalAmount - 100;
                Debug.Log(lower);
                if(ps.money > lower && ps.money < 1000){               
                    runGacha((lower/100));
                    return;
                } 
                totalAmount -= 100;
                Debug.Log(totalAmount);
            }
        } else {
            gachaUIController.DestroyItemPulled();
            if(ps.money > totalAmount){               
                runGacha((totalAmount/100));
                return;
            }

            while(true){
                lower = totalAmount - 100;
                Debug.Log(lower);
                if(ps.money > lower && ps.money < 1000){               
                    runGacha((lower/100));
                    return;
                } 
                totalAmount -= 100;
                Debug.Log(totalAmount);
            }
        }
    }
}
