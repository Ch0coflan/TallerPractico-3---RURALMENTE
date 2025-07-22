using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    private void LoadScene(int sceneIndex)
    {
        Debug.Log($"Cargando escena {sceneIndex}...");
        SceneManager.LoadScene(sceneIndex);
    }

    public void OnMapButton()
    {
        LoadScene(2);
    }

    public void OnMenuButton()
    {
        LoadScene(1);
    }
}
