using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
    public GameObject tutorialPanel;

    private void Start()
    {
        tutorialPanel.SetActive(true);
    }

    public void CloseTutorialPanel()
    {
        tutorialPanel.SetActive(false);
    }
}
