using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class timelineTrigger : MonoBehaviour
{
    public PlayableDirector scene1;
    public PlayableDirector scene2;

    public GameObject scene1Collider;

    private bool scene1Active = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (scene1Active && collision.tag == "scene1")
        {
            Debug.Log("trigger");

            scene1.Play();

            scene1Active = false;
        }

        /*

        if (active)
        {
            scene1.Play();

            active = false;
        }

        */
    }
}
