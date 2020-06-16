using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SideMenuButton : MonoBehaviour
{
    private Image image;
    private RectTransform RT;

    private void Start(){
        image = GetComponent<Image>();
        RT = GetComponent<RectTransform>();
    }

    public void FadeInAndOut(){
        //Debug.Log(image.color.a);
        float alpha = image.color.a;

        if(alpha >= 0.35f){
            image.DOFade(0.0f, 1.0f);
        } else if(alpha <= 0.2f){
            image.DOFade(0.5f, 1.0f);
        }
    }

    public void BGSlideInAndOut(){
        InAndOut(1.0f, -1050, -1000, new Vector2(-874.0f, 0.0f), new Vector2(-1162.0f, 0.0f));
    }

    public void SideButtonIAO(){
        IAOAndRotate(1.0f, -900, -850, 
                     new Vector2(-802.0f, 469.0f), new Vector2(-935.0f, 469.0f),
                     new Vector3(0.0f, 0.0f, 180.0f), new Vector3(0.0f, 0.0f, 0.0f));
    }

    public void ButtonListIAO(){
        InAndOut(1.0f, 0, 100, new Vector2(245.0f, 0.0f), new Vector2(-40.0f, 0.0f));
    }

    private void InAndOut(float time, int inLimit, int outLimit,
                         Vector2 newPos, Vector2 originPos){

        Vector2 pos = RT.anchoredPosition;                     
        if(pos.x <= inLimit){
            // Debug.Log("Moving In");
            RT.DOAnchorPos(newPos, time, true);
        } else if(pos.x >= outLimit){
            // Debug.Log("Moving Out");
            RT.DOAnchorPos(originPos, time, true);
        }
    }

    private void IAOAndRotate(float time, int inLimit, int outLimit,
                             Vector2 newPos, Vector2 originPos, 
                             Vector3 newRot, Vector3 originRot){

        Vector2 pos = RT.anchoredPosition;
        if(pos.x <= inLimit){
            // Debug.Log("Moving In");
            RT.DOAnchorPos(newPos, time, true);
            RT.DORotate(newRot, time);
        } else if(pos.x >= outLimit){
            // Debug.Log("Moving Out");
            RT.DOAnchorPos(originPos, time, true);
            RT.DORotate(originRot, time);
        }
    }
}
