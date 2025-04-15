using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    public UnityEvent onSelectCharacter;
    public EventTrigger EventTrigger;
    public Image charImage;
    public Outline outline;
    public GameObject homePanel;
    public GameObject routePanel;
    [SerializeField] private bool isRouteCompleted = false;


    private void Awake()
    {
        charImage = GetComponent<Image>();
        outline = GetComponent<Outline>();
        EventTrigger = GetComponent<EventTrigger>();
        homePanel.SetActive(true);
        routePanel.SetActive(false);
    }

    private void Settings()
    {
        isRouteCompleted = false;
        EventTrigger.enabled = true;
        charImage.color = Color.white;
    }

    public void OnClickedChar()
    {
        if (isRouteCompleted == false)
        {
            if (charImage != null)
            {
                homePanel.SetActive(false);
                routePanel.SetActive(true);
                onSelectCharacter?.Invoke();
            }
        }
    }

    public void OnEndedStory()
    {
        isRouteCompleted = true;
        
        if (isRouteCompleted)
        {
            Debug.Log("Historia Finalizada y marcada como completada");
            homePanel.SetActive(true);
            routePanel.SetActive(false);
            outline.enabled = false;
            EventTrigger.enabled = false;
            charImage.color = Color.gray;
        }
    }

    public void OnRestartStory()
    {
       Settings();
        Debug.Log("Historia Reiniciada");
    }
}

    
    
