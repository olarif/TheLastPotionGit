using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class scene2Trigger : MonoBehaviour
{
    public PlayableDirector scene2;
    private bool inRange;
    private bool hasTriggered = false;

    public GameObject shelfInventory;

    public void Update()
    {
        if (!hasTriggered && inRange && Input.GetKeyDown(KeyCode.E))
        {
            scene2.Play();
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
