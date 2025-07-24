using UnityEngine;
using UnityEngine.UI;

public class AudioMenuController : MonoBehaviour
{
    [SerializeField] private Toggle audioToggle;
    [SerializeField] private string musicSceneName = "UI Map"; 

    private void Start()
    {
        if (audioToggle == null)
        {
            audioToggle = GetComponent<Toggle>();
        }
        bool isAudioOn = PlayerPrefs.GetInt("audioOn", 1) == 1; // 1 por defecto (encendido)
        audioToggle.isOn = isAudioOn;
        ApplyAudioState(isAudioOn);

        // Escuchar cambios en el toggle
        audioToggle.onValueChanged.AddListener(ApplyAudioState);
    }

    public void ApplyAudioState(bool isOn)
    {
        PlayerPrefs.SetInt("audioOn", isOn ? 1 : 0);

        if (AudioManager.Instance == null)
        {
            return;
        }
        if (isOn)
        {
        AudioManager.Instance.Play(musicSceneName);
        }
        else
        {
            AudioManager.Instance.StopAllMusic();
        }

    }
}