using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSystem : MonoBehaviour
{
    public double money;
    // public List<GameObject> items;
    public TextMeshProUGUI timesX;
    public TextMeshProUGUI moneyCounter;

    private void Start(){
        TimesXButtonText();
        CountMoney();
    }

    public void TimesXButtonText(){
        if(money < 0){
            timesX.SetText("x0");
            return;
        }

        if(money >= 1000){
            timesX.SetText("x10");
            return;
        }

        int xText = (int) money / 100;
        timesX.SetText("x" + xText);            
        // Debug.Log(xText);
        // Debug.Log("x" + xText);
    }

    public void CountMoney(){
        moneyCounter.SetText("Money: $" + money);
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.M))
        {
            money += 900;
            TimesXButtonText();
            CountMoney();
        }
    }
}
