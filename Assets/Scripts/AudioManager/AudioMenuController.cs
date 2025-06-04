using UnityEngine;
using UnityEngine.UI;

public class AudioMenuController : MonoBehaviour
{
    [SerializeField] private Toggle audioToggle;

    private void Start()
    {
        audioToggle = GetComponent<Toggle>();
        
        // Asegurarse de que esté en el estado guardado previamente
        bool isAudioOn = PlayerPrefs.GetInt("audioOn", 1) == 1; // 1 por defecto (encendido)
        audioToggle.isOn = isAudioOn;
        ApplyAudioState(isAudioOn);

        // Escuchar cambios en el toggle
        audioToggle.onValueChanged.AddListener(ApplyAudioState);
    }

    public void ApplyAudioState(bool isOn)
    {
        PlayerPrefs.SetInt("audioOn", isOn ? 1 : 0);

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.musicSource.mute = !isOn;
            AudioManager.Instance.sfxSource.mute = !isOn;
        }
    }
}