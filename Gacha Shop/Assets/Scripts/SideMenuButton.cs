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
        Vector2 pos = RT.anchoredPosition;
        // Debug.Log(pos);
        // Debug.Log(pos.x);
        Vector2 newPos = new Vector2(-874.0f, 0.0f);
        Vector2 originPos = new Vector2(-1162.0f, 0.0f);

        if(pos.x <= -1050){
            // Debug.Log("Moving In");
            RT.DOAnchorPos(newPos, 1.0f, true);
        } else if(pos.x >= -1000){
            // Debug.Log("Moving Out");
            RT.DOAnchorPos(originPos, 1.0f, true);
        }
    }

    public void SideButtonIAO(){
        Vector2 pos = RT.anchoredPosition;
        // Debug.Log(pos);
        // Debug.Log(pos.x);
        Vector2 newPos = new Vector2(-802.0f, 469.0f);
        Vector2 originPos = new Vector2(-935.0f, 469.0f);
        Vector3 newRot = new Vector3(0.0f, 0.0f, 180.0f);
        Vector3 originRot = new Vector3(0.0f, 0.0f, 0.0f);

        if(pos.x <= -900){
            // Debug.Log("Moving In");
            RT.DOAnchorPos(newPos, 1.0f, true);
            RT.DORotate(newRot, 1.0f);
        } else if(pos.x >= -850){
            // Debug.Log("Moving Out");
            RT.DOAnchorPos(originPos, 1.0f, true);
            RT.DORotate(originRot, 1.0f);
        }
    }

}
