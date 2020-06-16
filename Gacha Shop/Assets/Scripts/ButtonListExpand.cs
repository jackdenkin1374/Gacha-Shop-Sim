using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


//Not Used
public class ButtonListExpand : MonoBehaviour
{
    public GameObject button1; //Vanity
    public GameObject button2; //Upgrades
    public GameObject button3; //Items
    public GameObject button4; //Gacha Pass
    public GameObject button5; // Expand Shop Button
    public GameObject button6; //Collection 
    public GameObject buttonList1; //Create Gacha
    private Button but;
    
    private void Start(){
        but = button5.GetComponent<Button>();
    }

    public void ExpandShopList(){
        but.interactable = false;
        InAndOut(button1, 1.0f, 270, 250, 
                 new Vector2(-1106.0f, 245.0f), new Vector2(-1106.0f, 277.0f));
        StartCoroutine(StartTimerInteractable(2.0f, but));
    }

    private void InAndOut(GameObject button, float time, int downLimit, int upLimit,
                         Vector2 newPos, Vector2 originPos){
        RectTransform RT = button.GetComponent<RectTransform>();
        Vector2 pos = RT.anchoredPosition;                     

        if(pos.y >= downLimit){
            // Debug.Log("Moving Down");
            button.SetActive(true);
            RT.DOAnchorPos(newPos, time, true);
        } else if(pos.y <= upLimit){
            // Debug.Log("Moving Up");
            RT.DOAnchorPos(originPos, time, true);    
            StartCoroutine(StartTimerSetActive(1.0f, button));        
        }
    }

    IEnumerator StartTimerSetActive(float time, GameObject obj){
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }

    IEnumerator StartTimerInteractable(float time, Button obj){
        yield return new WaitForSeconds(time);
        obj.interactable = true;
    }
}

