using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaSystem : MonoBehaviour
{
    public PlayerSystem ps;

    private ItemDatabase itemdatabase;

    public List<Item> rarityList = new List<Item>();
    
    // public List<GameObject> items;
    public int[] rates = {
        550, //Common
        300, //Uncommon
        100, //Rare
        50 // Legendary
    };

    public List<int> common;
    public List<int> uncommon;
    public List<int> rare;
    public List<int> legendary;

    private int total;
    private int rand;

    private void Start(){
        itemdatabase = ItemDatabase.Instance;

        Debug.Log(itemdatabase.Items[0].ItemName);
        rarityList.Add(itemdatabase.Items[0]);
        common.Add(itemdatabase.Items[0].Rarity);
        common.Add(itemdatabase.Items[1].Rarity);

        Debug.Log(rarityList[0].ItemName);
        Debug.Log(common[0]);
        Debug.Log(common[1]);
    }

    // public Item item;
    // public Text itemText;
    // public Image itemImage;
    
    // void SetupItemValues(){
    //     itemText.text = item.ItemName;
    //     itemImage.sprite = Resources.Load<Sprite>("UI/Icons/Common/" + item.ObjectSlug);
    // }

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
                if(rand < weight){
                    //award item
                    Debug.Log("Award: " + weight);
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

    public void TimesOnePull(){
        runGacha(1);
    }

    public void TimesXPull(){
        int totalAmount = 1000;
        int lower;
        if(ps.money < 0){
            Debug.Log("No money");
            return;
        }
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
