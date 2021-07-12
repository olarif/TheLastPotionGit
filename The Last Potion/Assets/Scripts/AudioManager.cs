using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // Singleton Instance
    public static AudioManager Instance { get; private set; }

    // FMOD Instances
    private FMOD.Studio.EventInstance ISoundtrack;

    // Scenes
    public String MenuScene;
    public String GameScene;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SwitchMusic();
    }

    void Start()
    {
        SetupInstance();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Ambience/Crow");
        }
    }

    void SetupInstance()
    {
        ISoundtrack = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Soundtrack");
        ISoundtrack.start();
    }

    void SwitchMusic()
    {
        if (SceneManager.GetActiveScene().name == MenuScene)
        {
            Debug.Log("Menu");
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("SceneName", 0f);
        }
        else if (SceneManager.GetActiveScene().name == GameScene)
        {
            Debug.Log("Outdoor");
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("SceneName", 1f);
        }
    }
}