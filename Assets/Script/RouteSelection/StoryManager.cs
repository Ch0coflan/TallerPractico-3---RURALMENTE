using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    public List<PanelData> story1 = new List<PanelData>();
    public List<PanelData> story2 = new List<PanelData>();
    public List<PanelData> story3 = new List<PanelData>();
    [Header("PanelData")]
    public TMP_Text infoText;
    public Button option1;
    public Button option2;
    public Image BG;
    public Image Character;
    public Transform optionContainer; 
    //public AudioSource characterAudioSource;

    private List<PanelData> currentStory;
    private int currentPanelIndex = 0;  

    void Start()
    {
        currentStory = story1;
        ShowPanel();
    }

    public void SetStory(int storyIndex)
    {
        switch (storyIndex)
        {
            case 0:
                currentStory = story1;
                break;
            case 1:
                currentStory = story2;
                break;
            case 2:
                currentStory = story3;
                   break;
            default:
                currentStory = story1;
                break;
        }
        currentPanelIndex = 0;
        ShowPanel();
    }

    void ShowPanel()
    {
        if (currentPanelIndex >= currentStory.Count)
        {
            Debug.Log("Fin de la historia.");
            return;
        }

        PanelData currentPanel = currentStory[currentPanelIndex];
        infoText.text = currentPanel.text;

        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);

        if (currentPanel.options.Count > 0)
        {
            option1.gameObject.SetActive(true);
            option1.GetComponentInChildren<TMP_Text>().text = currentPanel.options[0].optionText;
            option1.onClick.RemoveAllListeners();
            option1.onClick.AddListener(() => OnOptionSelected(currentPanel.options[0]));

            if(currentPanel.options.Count > 1)
            {
                option2.gameObject.SetActive(true);
                option2.GetComponentInChildren<TMP_Text>().text = currentPanel.options[1].optionText;
                option2.onClick.RemoveAllListeners();
                option2.onClick.AddListener(() => OnOptionSelected(currentPanel.options[0]));
            }

        }
    }

    void OnOptionSelected(PanelOption option)
    {
        currentPanelIndex = option.nextPanelIndex; 
        ShowPanel();  
    }
}
