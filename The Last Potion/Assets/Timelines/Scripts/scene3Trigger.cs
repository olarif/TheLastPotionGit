using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class scene3Trigger : MonoBehaviour
{
    public PlayableDirector scene1;

    private bool hasTriggered = false;
    private bool inRange;

    public void Update()
    {
        if (!hasTriggered && inRange && GameManager.instance.potionBool)
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
