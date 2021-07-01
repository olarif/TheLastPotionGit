using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Singleton Instance
    public static AudioManager Instance { get; private set; }

    // FMOD Instances
    private FMOD.Studio.EventInstance IMusic;


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
    }

    void Start()
    {
        SetupInstances();
        IMusic.start();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Ambience/Crow");
        }
    }

    void SetupInstances()
    {
        IMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Music");
    }
}
