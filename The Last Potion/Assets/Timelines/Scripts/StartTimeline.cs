using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StartTimeline : MonoBehaviour
{

    public void StartScene(PlayableDirector scene)
    {
        scene.Play();
    }

    public void StopScene(PlayableDirector scene)
    {
        scene.Stop();
    }
}
