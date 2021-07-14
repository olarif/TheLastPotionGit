using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class timelineTrigger : MonoBehaviour
{
    public PlayableDirector director;
    private bool active = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active)
        {
            director.Play();

            active = false;
        }
    }
}
