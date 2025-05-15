using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class MenuModel : MonoBehaviour
    {
        public GameObject mainPanel;
        public GameObject settingsPanel;
        public GameObject creditsPanel;
        public Button settingsBackButton;
        public Button creditsBackButton;
        
        [Header("Game Mood")]
        public GameObject pausePanel;
        public GameObject gameOverPanel;
    }
}