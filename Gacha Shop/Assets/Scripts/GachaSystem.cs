using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaSystem : MonoBehaviour
{
    public PlayerSystem ps;
    
    // public List<GameObject> items;
    public int[] rates = {
        550, //Common
        300, //Uncommon
        100, //Rare
        50 // Legendary
    };

    public int[] common = {
        
    };

    public int[] uncommon = {

    };

    public int[] rare = {

    };

    public int[] legendary = {

    };

    private int total;
    private int rand;

    private void Start(){
        ps = FindObjectOfType(typeof(PlayerSystem)) as PlayerSystem;
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
