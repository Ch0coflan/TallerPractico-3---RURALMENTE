using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class SceneManager : MonoBehaviour
{
    public GameObject transitionGO;
 
    bool isFadingIn = true;
    public GameObject current;
 
    public void TransformToImage(GameObject target){
        StartCoroutine(FadeInAndOut(target));
    }
 
    IEnumerator FadeInAndOut(GameObject target){
        int fadeSpeed = 3;
        Image transitionImage = transitionGO.GetComponent<Image>();
        transitionImage.raycastTarget = true;
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
        current.SetActive(false);
        target.SetActive(true);
        current = target;
 
        while (!isFadingIn) {
            transitionColor.a -= fadeSpeed * Time.deltaTime;
            if (transitionColor.a <= 0) {
                transitionColor.a = 0;
                isFadingIn = true;
            }
            transitionImage.color = transitionColor;
            yield return new WaitForEndOfFrame();
        }
        
    }
}