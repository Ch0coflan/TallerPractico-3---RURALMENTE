using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class PanelManager : MonoBehaviour
{
    public void TransformToImage(GameObject target)
    {
        target.SetActive(true);
       // current.SetActive(false);
    }

    public void CloseUI (GameObject target)
    {
        //panels = GameObject.Find(name);
        target.SetActive(false);
    }
}

