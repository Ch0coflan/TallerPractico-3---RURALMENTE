using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    public UnityEvent onEndedFirstStory;
    public UnityEvent onEndedSecondStory;
    public UnityEvent onEndedThirdStory;
    public UnityEvent onEndedFourthStory;
    public UnityEvent onEndedFifthStory;
    public UnityEvent onExitButton;
    public List<PanelData> story1 = new List<PanelData>();
    public List<PanelData> story2 = new List<PanelData>();
    public List<PanelData> story3 = new List<PanelData>();
    public List<PanelData> story4 = new List<PanelData>();
    public List<PanelData> story5 = new List<PanelData>();
    [SerializeField] private int _storyID;
    [Header("PanelData")]
    public TMP_Text infoText;
    public Button option1;
    public Button option2;
    public Button returnButton;
    public Image BG;
    public Image Character;
    public Transform optionContainer; 
    //public AudioSource characterAudioSource;
    //public Animator animator;

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
            3 => story4,
            4 => story5,
            _ => story1,
        };
        currentPanelIndex = 0;
        _storyID = storyIndex;
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
            Debug.LogWarning("�ndice fuera de rango.");
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
        DecisionTracker.Instance.TrackDecision(option.isGoodDecision);
        currentPanelIndex = option.nextPanelIndex;
        BG.sprite = option.BG;
        Character.sprite = option.Character;
        ShowPanel();  
    }

    public void FinishedStory()
    {
        switch (_storyID)
        {
            case 0: ReturnToMenu1(); break;
            case 1: ReturnToMenu2(); break;
            case 2: ReturnToMenu3(); break;
            case 3: ReturnToMenu4(); break;
            case 4: ReturnToMenu5(); break;
        }
    }
        
    public void ReturnToMenu1()
    {
        onEndedFirstStory?.Invoke();
        LoopManager.instance.SetStoryAsCompleted(_storyID);
        returnButton.gameObject.SetActive(false);
    }

    public void ReturnToMenu2()
    {
        onEndedSecondStory?.Invoke();
        LoopManager.instance.SetStoryAsCompleted(_storyID);
        returnButton.gameObject.SetActive(false);
    }

    public void ReturnToMenu3()
    {
        onEndedThirdStory?.Invoke();
        LoopManager.instance.SetStoryAsCompleted(_storyID);
        returnButton.gameObject.SetActive(false);
    }

    public void ReturnToMenu4()
    {
        onEndedFourthStory?.Invoke();
        LoopManager.instance.SetStoryAsCompleted(_storyID);
        returnButton.gameObject.SetActive(false);
    }

    public void ReturnToMenu5()
    {
        onEndedFifthStory?.Invoke();
        LoopManager.instance.SetStoryAsCompleted(_storyID);
        returnButton.gameObject.SetActive(false);
    }

    public void ReturnToMenuExit()
    {
        onExitButton?.Invoke();
        currentPanelIndex = 0;
        currentStory = null;   
    }
}
