using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class scene1Trigger : MonoBehaviour
{
    public PlayableDirector scene1;
    public GameObject chatBubble;

    private bool inRange;

    public void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            scene1.Play();
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
