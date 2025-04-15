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
       
    public void OnClickedChar()
    {
        if (charImage != null)
        {
            homePanel.SetActive(false);
            routePanel.SetActive(true);
            onSelectCharacter?.Invoke();
        }
    }

    public void OnEndedStory()
    {
        isRouteCompleted = true;
        homePanel.SetActive(true);
        routePanel.SetActive(false);
        outline.enabled = false;
        EventTrigger.enabled = false;
        if (isRouteCompleted)
        {
            charImage.color = Color.gray;
        }
    }
}

    
    
