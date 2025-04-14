using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    public UnityEvent onSelectCharacter;
    public int storyIndex;
    public Image charImage;
    public GameObject homePanel;
    public GameObject routePanel;
    [SerializeField] private bool isRouteCompleted = false;


    private void Awake()
    {
        charImage = GetComponent<Image>();
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
        if (isRouteCompleted)
        {
            charImage.color = Color.gray;
        }
    }
}

    
    
