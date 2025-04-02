using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
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
        }
    }
}

    
    
