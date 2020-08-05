using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaSystem : MonoBehaviour
{
    public PlayerSystem ps;
    public RectTransform gachaPullPanel;
    public GachaUIController gachaUIController;

    private ItemDatabase itemdatabase;
    private InventoryController inventory;
    
    public int[] rates = {
        550, //Common
        300, //Uncommon
        100, //Rare
        50 // Legendary
    };

    private int total;
    private int rand;
    public GachaPass currentGacha;

    private void Start(){
        itemdatabase = ItemDatabase.Instance;
        inventory = InventoryController.Instance;
        currentGacha = itemdatabase.Beginner_Pool;

        Debug.Log("Current Gacha is " + currentGacha.name);

        // Debug.Log(currentGacha.name);
        // Debug.Log(currentGacha.common.Count);
        // Debug.Log(currentGacha.uncommon.Count);
        // Debug.Log(currentGacha.rare.Count);
        // Debug.Log(currentGacha.legendary.Count);

        // Debug.Log("Beginner Pool Common count is " + itemdatabase.Beginner_Pool.common.Count);
        // Debug.Log("Beginner Pool Uncommon count is " + itemdatabase.Beginner_Pool.uncommon.Count);
        // Debug.Log("Beginner Pool Rare count is " + itemdatabase.Beginner_Pool.rare.Count);
        // Debug.Log("Beginner Pool Legendary count is " + itemdatabase.Beginner_Pool.legendary.Count);

        // Debug.Log("Deserted Town Common count is " + itemdatabase.Deserted_Town.common.Count);
        // Debug.Log("Deserted Town Uncommon count is " + itemdatabase.Deserted_Town.uncommon.Count);
        // Debug.Log("Deserted Town Rare count is " + itemdatabase.Deserted_Town.rare.Count);
        // Debug.Log("Deserted Town Legendary count is " + itemdatabase.Deserted_Town.legendary.Count);

        // Debug.Log("Forge Common count is " + itemdatabase.Forge.common.Count);
        // Debug.Log("Forge Uncommon count is " + itemdatabase.Forge.uncommon.Count);
        // Debug.Log("Forge Rare count is " + itemdatabase.Forge.rare.Count);
        // Debug.Log("Forge Legendary count is " + itemdatabase.Forge.legendary.Count);

        // Debug.Log("Lifetime Common count is " + itemdatabase.Once_In_A_Lifetime.common.Count);
        // Debug.Log("Lifetime Uncommon count is " + itemdatabase.Once_In_A_Lifetime.uncommon.Count);
        // Debug.Log("Lifetime Rare count is " + itemdatabase.Once_In_A_Lifetime.rare.Count);
        // Debug.Log("Lifetime Legendary count is " + itemdatabase.Once_In_A_Lifetime.legendary.Count);
    }

    private void runChanceRand(int total){
        rand = Random.Range(0, total);
        foreach(var weight in rates){
            if(rand <= weight){
                //award item
                runRarity(weight);
                break;
            } else {
                rand -= weight;
            }
        }
    }

    private void runGacha(int count){      
        for(int x = 0; x < count; x++){
            Debug.Log("Pulling " + (x+1));
            total = 0;

            foreach(var item in rates){
                total += item;
            }

            runChanceRand(total);

            ps.money -= 100;
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
                if(currentGacha.common.Count == 0){
                    runRarity(300);
                }
                runRandAndList(currentGacha.common);
            break;

            case 300:
                Debug.Log("Uncommon Pull");
                if(currentGacha.uncommon.Count == 0){
                    runRarity(100);
                }
                runRandAndList(currentGacha.uncommon);
            break;

            case 100:
                Debug.Log("Rare Pull");
                if(currentGacha.rare.Count == 0){
                    runRarity(50);
                }
                runRandAndList(currentGacha.rare);
            break;

            case 50:
                Debug.Log("Legendary Pull");
                if(currentGacha.legendary.Count == 0){
                    runRarity(550);
                }
                runRandAndList(currentGacha.legendary);
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
