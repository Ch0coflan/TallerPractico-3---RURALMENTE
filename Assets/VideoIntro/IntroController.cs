using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    public VideoPlayer player;

    private void OnEnable()
    {
        player.loopPointReached += EndVideo;
    }

    private void OnDisable()
    {
        player.loopPointReached -= EndVideo;
    }

    private void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.Play();
    }

    private void EndVideo(VideoPlayer vp)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
