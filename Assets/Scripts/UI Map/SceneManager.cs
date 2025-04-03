using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class SceneManager : MonoBehaviour
{
    public GameObject transitionGO;
 
    bool isFadingIn = true;
    public GameObject current;
 
    public void TransformToImage(GameObject target){
        target.SetActive(true);
        current.SetActive(false);
        
        /* Image transitionImage = current.GetComponent<Image>();
         // transitionImage.raycastTarget = true;
         transitionImage.sprite = target.GetComponent<SpriteRenderer>().sprite;
        StartCoroutine(FadeInAndOut(target));*/
     }
/*
     IEnumerator FadeInAndOut(GameObject target){
         int fadeSpeed = 3;

         /*
         Color transitionColor = transitionImage.color;

         while (isFadingIn) {
             transitionColor.a += fadeSpeed * Time.deltaTime;
             if (transitionColor.a >= 1) {
                 isFadingIn = false;
                 transitionColor.a = 1;
             }
             transitionImage.color = transitionColor;
             yield return new WaitForEndOfFrame();
         }
         transitionImage.raycastTarget = false;
         */
       /* current.SetActive(false);
        target.SetActive(true);
        current = target;*/
 /*
        while (!isFadingIn) {
            transitionColor.a -= fadeSpeed * Time.deltaTime;
            if (transitionColor.a <= 0) {
                transitionColor.a = 0;
                isFadingIn = true;
            }
            transitionImage.color = transitionColor;
            yield return new WaitForEndOfFrame();
        }
        */
    
}