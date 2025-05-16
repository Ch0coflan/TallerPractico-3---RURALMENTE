using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Managers;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        public MenuModel model;
        public MenuView view;

        private void Start()
        {
            Debug.Log("MenuController Start() ejecutándose...");
            AssignButtonEvents();

            // Asegurarse de que el cursor está visible y desbloqueado en el menú
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }


        private void AssignButtonEvents()
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            Debug.Log("Asignando eventos a los botones...");

            // Menú principal
            AssignButton(view.playButton, () => LoadScene(sceneIndex));
            AssignButton(view.settingsButton, () => SwitchPanel(model.mainPanel, model.settingsPanel));
            AssignButton(view.creditsButton, () => SwitchPanel(model.mainPanel, model.creditsPanel)); // Verifica esta línea
            AssignButton(view.exitButton, Application.Quit);
            AssignButton(view.settingsBackButton, () => SwitchPanel(model.settingsPanel, model.mainPanel));
            AssignButton(view.creditsBackButton, () => SwitchPanel(model.creditsPanel, model.mainPanel));

            // Menú de pausa y Game Over
            AssignButton(view.restartButton, RestartGame);
            AssignButton(view.continueButton, () => {});
            AssignButton(view.MapReturnButton, RestartGame);
            AssignButton(view.mainMenuButton, ReturnToMainMenu);
            AssignButton(view.gameOverMainMenuButton, ReturnToMainMenu);
        }

        // Método genérico para asignar eventos a botones
        private void AssignButton(Button button, UnityEngine.Events.UnityAction action)
        {
            if (button != null)
            {
                button.onClick.RemoveAllListeners(); // Limpiar eventos previos
                button.onClick.AddListener(action);
                Debug.Log($"Evento asignado a {button.name}");
            }
            else
            {
                Debug.LogWarning("Un botón no está asignado en el Inspector.");
            }
        }

        // Cambiar entre paneles
        private void SwitchPanel(GameObject current, GameObject next)
        {
            if (current != null && next != null)
            {
                current.SetActive(false);
                next.SetActive(true);
                Debug.Log($"Cambiando panel de {current.name} a {next.name}");
            }
            else
            {
                Debug.LogWarning("Panel references are missing!");
            }
        }

        // Cargar una escena
        private void LoadScene(int sceneIndex)
        {
            Debug.Log($"Cargando escena {sceneIndex}...");
            SceneManager.LoadScene(sceneIndex);
            AudioManager.Instance.PlayMusic("MusicaAmbiente");
        }

        // Reiniciar el juego
        private void RestartGame()
        {
            Debug.Log("Reiniciando el juego...");
                SceneManager.LoadScene(1);
        }

        // Regresar al menú principal
        private void ReturnToMainMenu()
        {
            Debug.Log("Regresando al menú principal...");

                Time.timeScale = 1; // Restablecer el tiempo
                Cursor.visible = true; // Asegurar que el cursor es visible
                Cursor.lockState = CursorLockMode.None; // Desbloquear el cursor
                SceneManager.LoadScene(0); // Cargar la escena del menú principal

        }

      /*  public IEnumerator Transition(int sceneIndex)
        {
            Debug.Log("Ejecutando corroutina");
            yield return new WaitForSeconds(2);
            LoadScene(sceneIndex);

        }*/

    }
}
