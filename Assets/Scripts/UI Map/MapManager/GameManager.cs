// GameManager.cs
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public GameObject gameEventCanvas;
        public GameObject pausePanel;
        public GameObject gameOverPanel;
        public GameObject toBeContinuedPanel;

        private bool isPaused = false;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Cursor.visible = false;

            gameEventCanvas.SetActive(false);
            pausePanel.SetActive(false);
            gameOverPanel.SetActive(false);
            toBeContinuedPanel.SetActive(false);
        }

        public void TogglePause(bool? pauseState = null)
        {

            if (pauseState.HasValue)
            {
                isPaused = pauseState.Value;
                Cursor.visible = true;
            }
            else
            {
                isPaused = !isPaused;
                Cursor.visible = false;
            }

            pausePanel.SetActive(isPaused);
            Time.timeScale = isPaused ? 0 : 1;
            Cursor.visible = isPaused;
            Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
            gameEventCanvas.SetActive(isPaused); // Asegúrate de activar el Canvas si es necesario
        }

        public void ShowGameOver()
        {
            Cursor.visible = true;

            gameEventCanvas.SetActive(true);
            gameOverPanel.SetActive(true);
            Time.timeScale = 0; // Pausar el juego
            Cursor.visible = true; // Mostrar el cursor
            Cursor.lockState = CursorLockMode.None; // Desbloquear el cursor
        }

        public void ShowToBeContinued() // Agregar este método
        {
            Cursor.visible = true;

            gameEventCanvas.SetActive(true);
            toBeContinuedPanel.SetActive(true);
            Time.timeScale = 2;
        }

        // Método para el botón de pausa
        public void TogglePauseButton()
        {
            TogglePause(false); // Esto continuará el juego
        }
    }
}