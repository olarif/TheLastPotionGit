using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToWife : MonoBehaviour
{
    public GameObject chatBubble;
    public Conversation testConvo;
    private bool inRange;
    private bool inProgress = false;

    private void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && !inProgress)
            {
                DialogueManager.StartConversation(testConvo);
                inProgress = true;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        chatBubble.SetActive(true);
        inRange = true;
        inProgress = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        chatBubble.SetActive(false);
        inRange = false;
        inProgress = false;
        DialogueManager.StopConversation();
    }
}
