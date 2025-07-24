using UnityEngine;
using UnityEngine.UI;

public class MenuDemoProx : MonoBehaviour
{
    public Button exitButton;
    public GameObject demoPanel;

    public void Start()
    {
        demoPanel.SetActive(false);
    }

    public void OpenPanel()
    {
        demoPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        demoPanel.SetActive(false);
    }
}
