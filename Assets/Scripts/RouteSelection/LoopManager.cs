using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoopManager : MonoBehaviour
{
  public static LoopManager instance;

    [Header("Stories status")]
    public bool[] finishedStories = new bool[3];

    [Header("UI Info")]
    public GameObject panelInfo;
    public Button restartButton;

    [Header("Events")]
    public UnityEvent onAllStoriesFinished;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        panelInfo.SetActive(false);
    }

    public void SetStoryAsCompleted(int id)
    {
        finishedStories[id] = true;
        if(AllStoriesFinished())
        {
            ShowPanel();
        }
    }

    public bool AllStoriesFinished()
    {
        foreach (var story in finishedStories)
        {
            if(!story) return false;
        }
        return true;
    }

    private void ShowPanel()
    {
        panelInfo.SetActive(true);
        restartButton.interactable = true;
    }

    public void RestartProgress()
    {
        for(int i = 0; i < finishedStories.Length; i++)
        {
            finishedStories[i] = false;
        }
        onAllStoriesFinished.Invoke();
        panelInfo.SetActive(false);
        restartButton.interactable = false;
    }
}
