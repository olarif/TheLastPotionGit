using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // FMOD Instances
    private FMOD.Studio.EventInstance IMusic;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SetupInstances();
        IMusic.start();
    }

    // Update is called once per frame
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
