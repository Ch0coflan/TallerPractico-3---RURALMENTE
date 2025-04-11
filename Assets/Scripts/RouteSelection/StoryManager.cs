using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    public UnityEvent onEndedStory;
    public List<PanelData> story1 = new List<PanelData>();
    public List<PanelData> story2 = new List<PanelData>();
    public List<PanelData> story3 = new List<PanelData>();
    [Header("PanelData")]
    public TMP_Text infoText;
    public Button option1;
    public Button option2;
    public Button returnButton;
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
        returnButton.gameObject.SetActive(false);
    }

    public void SetStory(int storyIndex)
    {
        currentStory = storyIndex switch
        {
            0 => story1,
            1 => story2,
            2 => story3,
            _ => story1,
        };
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
        if (currentPanelIndex < 0 || currentPanelIndex >= currentStory.Count)
        {
            Debug.LogWarning("Índice fuera de rango.");
            return;
        }
        PanelData currentPanel = currentStory[currentPanelIndex];
        infoText.text = currentPanel.text;

        if (currentPanel != null)
        {
            option1.gameObject.SetActive(false);
            option2.gameObject.SetActive(false);

            if (currentPanel.options.Count > 0)
            {
                option1.gameObject.SetActive(true);
                option1.GetComponentInChildren<TMP_Text>().text = currentPanel.options[0].optionText;
                option1.onClick.RemoveAllListeners();
                option1.onClick.AddListener(() => OnOptionSelected(currentPanel.options[0]));
                
                if (currentPanel.options.Count > 1)
                {
                    option2.gameObject.SetActive(true);
                    option2.GetComponentInChildren<TMP_Text>().text = currentPanel.options[1].optionText;
                    option2.onClick.RemoveAllListeners();
                    option2.onClick.AddListener(() => OnOptionSelected(currentPanel.options[1]));
                }
            }

            if(currentPanel.isEndPanel)
            {
                option1.gameObject.SetActive(false);
                option2.gameObject.SetActive(false);
                returnButton.gameObject.SetActive(true);
            }
        }
    }
               
    void OnOptionSelected(PanelOption option)
    {
        if (option.nextPanelIndex < 0 || option.nextPanelIndex >= currentStory.Count)
        {
            Debug.LogError("nextPanelIndex fuera de rango: " + option.nextPanelIndex);
            return;
        }
        currentPanelIndex = option.nextPanelIndex;
        BG.sprite = option.BG;
        Character.sprite = option.Character;
        ShowPanel();  
    }

    public void ReturnToMenu()
    {
        onEndedStory?.Invoke();
        returnButton.gameObject.SetActive(false);
    }
}
