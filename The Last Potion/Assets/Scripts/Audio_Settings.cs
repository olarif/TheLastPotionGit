using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Settings : MonoBehaviour
{
    // FMOD Instances
    private FMOD.Studio.EventInstance SFXVolumeTestEvent;

    FMOD.Studio.Bus Master; 
    FMOD.Studio.Bus Music;
    FMOD.Studio.Bus SFX;

    float MasterVolume = 1f;
    float MusicVolume = 0.5f;
    float SFXVolume = 0.5f;


    private void Awake()
    {
        Master = FMODUnity.RuntimeManager.GetBus("bus:/Master"); 
        Music = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        SFX = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFX");
        SFXVolumeTestEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/SFXVolumeTest");
    }

    // Update is called once per frame
    void Update()
    {
        Master.setVolume(MasterVolume);
        Music.setVolume(MusicVolume);
        SFX.setVolume(SFXVolume);
    }

    public void MasterVolumeLevel (float newMasterVolume)
    {
        MasterVolume = newMasterVolume;

        // Only plays if it sopped playing before
        FMOD.Studio.PLAYBACK_STATE PbState;
        SFXVolumeTestEvent.getPlaybackState(out PbState);
        if (PbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            SFXVolumeTestEvent.start();
        }
    }

    public void MusicVolumeLevel(float newMusicVolume)
    {
        MusicVolume = newMusicVolume;
    }

    public void SFXVolumeLevel(float newSFXVolume)
    {
        SFXVolume = newSFXVolume;

        // Only plays if it sopped playing before
        FMOD.Studio.PLAYBACK_STATE PbState;
        SFXVolumeTestEvent.getPlaybackState(out PbState);
        if (PbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            SFXVolumeTestEvent.start();
        }
    }
}
