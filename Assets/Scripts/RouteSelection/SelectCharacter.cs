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
        homePanel.SetActive(true);
        routePanel.SetActive(false);
        charImage.color = Color.gray;
    }
}

    
    
