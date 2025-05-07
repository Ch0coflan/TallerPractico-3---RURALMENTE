using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public Animator anim;
    public GameObject fadeTransition;
    private void LoadScene(int sceneIndex)
    {
        Debug.Log($"Cargando escena {sceneIndex}...");
        SceneManager.LoadScene(sceneIndex);
    }

    public IEnumerator TransitionScenes(int sceneIndex)
    {
        Debug.Log("Ejecutando corroutina");
        yield return new WaitForSeconds(2);
        LoadScene(sceneIndex);

    }
    public void OnMapButton()
    {
        fadeTransition.SetActive(true);
        anim.SetTrigger("Out");
        StartCoroutine(TransitionScenes(1));
    }

    public void OnMenuButton()
    {
        fadeTransition.SetActive(true);
        anim.SetTrigger("Out");
        StartCoroutine(TransitionScenes(0));
    }

    public void AnimEvent()
    {
        fadeTransition.gameObject.SetActive(false);
    }
}
