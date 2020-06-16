using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShadowOverlayFade : MonoBehaviour
{
    public GameObject obj;
    private Image image;

    private void Start(){
        image = GetComponent<Image>();
        obj.SetActive(false);
    }

    public void FadeInAndOut(){
        //Debug.Log(image.color.a);
        obj.SetActive(true);
        float alpha = image.color.a;

        if(alpha >= 0.35f){
            image.DOFade(0.0f, 1.0f);
            StartCoroutine(StartTimerSetActive(1.0f, obj));
        } else if(alpha <= 0.2f){
            image.DOFade(0.5f, 1.0f);
        }
    }

    IEnumerator StartTimerSetActive(float time, GameObject gObj){
        yield return new WaitForSeconds(time);
        gObj.SetActive(false);
    }
}
