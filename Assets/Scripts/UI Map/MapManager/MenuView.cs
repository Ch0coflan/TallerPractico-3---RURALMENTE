using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class MenuView : MonoBehaviour
    {
        [Header("Menu Buttons")]
        public Button playButton;
        public Button settingsButton;
        public Button creditsButton;
        public Button exitButton;
        public Button settingsBackButton;
        public Button creditsBackButton;
        
        [Header("Game Mode")]
        public Button continueButton;
        public Button restartButton;
        public Button MapReturnButton;
        public Button mainMenuButton;
        public Button gameOverMainMenuButton;
    }
}