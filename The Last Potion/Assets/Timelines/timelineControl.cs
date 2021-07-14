using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class timelineControl : MonoBehaviour
{
    public PlayableDirector director;


    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
    }

    public void checkDialogue()
    {
        if (DialogueManager.instance.isActive)
        {
            director.Pause();
        } else
        {
            director.Play();
        }
    }

    void Update()
    {
        
    }
}
