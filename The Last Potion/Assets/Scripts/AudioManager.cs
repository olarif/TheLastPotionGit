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

    // Parameter
    private float SoundtrackParam = 0f;

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

        SwitchMusicOnScene();
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

    void SwitchMusicOnScene()
    {
        if (SceneManager.GetActiveScene().name == MenuScene)
        {
            //Debug.Log("Menu");
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("SceneName", 0f);
            //SoundtrackParam = 0f;
        }
        else if (SceneManager.GetActiveScene().name == GameScene)
        {
            //Debug.Log("Outdoor");
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("SceneName", 1f);
            //SoundtrackParam = 1f;
        }
    }

    void SwitchMusicOnTrigger()
    {

    }

    public void StartMusicFirstFloor()
    {
        SoundtrackParam = 2f;
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("SceneName", SoundtrackParam);
    }
    public void StartMusicOutdoor()
    {
        SoundtrackParam = 1f;
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("SceneName", SoundtrackParam);
    }
}