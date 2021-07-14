using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class scene2Trigger : MonoBehaviour
{
    public PlayableDirector scene2;
    public GameObject chatBubble;

    private bool inRange;

    public void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            scene2.Play();
            chatBubble.SetActive(false);
            inRange = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
        chatBubble.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
        chatBubble.SetActive(false);
    }
}
