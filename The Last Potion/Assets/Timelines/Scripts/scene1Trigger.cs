using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class scene1Trigger : MonoBehaviour
{
    public PlayableDirector scene1;

    private bool hasTriggered = false;
    private bool inRange;

    public void Update()
    {
        if (!hasTriggered && inRange && Input.GetKeyDown(KeyCode.E))
        {
            scene1.Play();
            inRange = false;
            hasTriggered = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
    }
}