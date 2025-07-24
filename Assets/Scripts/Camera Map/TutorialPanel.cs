using TMPro;
using UnityEngine;

namespace Camera_Map
{
    public class TutorialPanel : MonoBehaviour
    {
        public GameObject tutorialPanel;
        public TMP_Text tutorialText;
        public string tutorialTextAndroid;
        public string tutorialTextPC;
        public string tutorialTextWebGL;

        private void Start()
        {
            tutorialPanel.SetActive(true);
            switch (Application.platform)
            {
                case (RuntimePlatform.Android):
                    tutorialText.text = tutorialTextAndroid;
                    break;
                case (RuntimePlatform.WindowsPlayer):
                    tutorialText.text = tutorialTextPC;
                    break;
                case (RuntimePlatform.WebGLPlayer):
                    tutorialText.text = tutorialTextWebGL;
                    break;
            }
        }

        public void CloseTutorialPanel()
        {
            tutorialPanel.SetActive(false);
        }
        
        
    }
}
