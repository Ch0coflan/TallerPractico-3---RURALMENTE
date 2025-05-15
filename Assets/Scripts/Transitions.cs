using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Transitions : MonoBehaviour
{
    public Animator animator;
    public float transitionTime;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            SetScene();
        }
    }

    public void SetScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(TransitionScene(sceneIndex));
    }
        

    public IEnumerator TransitionScene(int sceneIndex)
    {
        animator.SetTrigger("Out");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
