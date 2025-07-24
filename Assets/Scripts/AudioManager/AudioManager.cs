using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds;
    public AudioSource musicSource, sfxSource;
    public string currentScene;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeSounds();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
   
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentScene = scene.name;
        PlayMusic(currentScene);
    }

    private void InitializeSounds()
    {
        foreach (Sound s in musicSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = true; 
            s.source.playOnAwake = false; 
        }
    }

    public void PlayMusic(string sceneName)
    {
        StopAllMusic();
        switch (sceneName)
        {
            case "UI Map":
                Play("Menu");
                break;
            case "SceneMap":
                Play("Mapa");
                break;
            case "ChocoScene":
                Play("Familia");
                break;
                
        }
    }

    public void Play(string trackName)
    {
        Sound s = System.Array.Find(musicSounds, sound => sound.name == trackName);
        if (s == null)
        {
            Debug.LogWarning("Sound not found: " + trackName);
            return;
        }
        s.source.Play();
    }
    
    public void StopAllMusic()
    {
        foreach (Sound s in musicSounds)
        {
            s.source.Stop();    
        }
    }
}

/*
   Sound s = Array.Find(musicSounds, x => x.name == sceneName);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
 
 
 
 
 
 public void PlaySFX(string name)
 {
     Sound s = Array.Find(sfxSounds, x => x.name == name);

     if (s == null)
     {
         Debug.Log("Sound Not Found");
     }

     else
     {
         sfxSource.PlayOneShot(s.clip);
     }
 }

 //UI Sound Controls
 public void ToggleMusic()
 {
     musicSource.mute = !musicSource.mute;
 }
 public void ToggleSFX()
 {
     sfxSource.mute = !sfxSource.mute;
 }












 //public void MusicVolume(float volume)
 //{
 //musicSource.volume = volume;
 //}
 // public void SFXVolume(float volume)
 // {
 // sfxSource.volume = volume;
 //}

 //To call the PlaySfx
 //AudioManager.Instance.PlaySFX("Nombre del SFX");

 //To stop music
 //AudioManager.Instance.musicSource.stop();
 */