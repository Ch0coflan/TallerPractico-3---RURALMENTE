using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }
    public delegate void EventoPanel(string panelName);
    public static event EventoPanel OnCharacterSelected;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Instance = this;
        }else
        {
            Destroy(gameObject);
        }
    }

    public static void RouteSelected(string panelName)
    {
        OnCharacterSelected?.Invoke(panelName);
    }
  


}
