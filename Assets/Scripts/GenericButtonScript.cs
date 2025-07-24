using System;
using UnityEngine;

public class GenericButtonScript : MonoBehaviour
{
   public GameObject panel;

  public void ClosePanel()
   {
      Debug.Log($"The gameobject {panel.name} has been clicked.");
      panel.SetActive(false);
   }
}
  
