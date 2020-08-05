using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabGachaGroup : MonoBehaviour
{
    public List<TabGacha> tabButtons;
    public Color tabIdle;
    public Color tabHover;
    public Color tabActive;
    public TabGacha selectedTab;
    public Image image;
    public TextMeshProUGUI title;
    private ItemDatabase itemdatabase;
    public GachaSystem gacha;

    public void Start(){
        itemdatabase = ItemDatabase.Instance;
    }

    public void Subscribe(TabGacha button){
        if(tabButtons == null){
            tabButtons = new List<TabGacha>();
        }
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabGacha button){
        ResetTabs();
        if(selectedTab == null || button != selectedTab){
            button.background.color = tabHover;
        }
    }

    public void OnTabExit(TabGacha button){
        ResetTabs();
    }

    public void OnTabSelected(TabGacha button){
        if(selectedTab != null){
            selectedTab.Deselect();
        }
        selectedTab = button;
        selectedTab.Select();
        
        ResetTabs();
        button.background.color = tabActive;
        int index = button.transform.GetSiblingIndex();
        foreach(GachaPass pass in itemdatabase.listOfGachas){
            if(button.gameObject.name == pass.name){
                image.sprite = Resources.Load<Sprite>("UI/GachaPass/" + pass.objectSlug);
                title.text = pass.name;
                gacha.currentGacha = pass;
                Debug.Log("Current Gacha is " + gacha.currentGacha.name);
            }
        }
    }

    public void ResetTabs(){
        foreach(TabGacha button in tabButtons){
            if(selectedTab != null && button == selectedTab){ continue; }
            button.background.color = tabIdle;
        }
    }
}
