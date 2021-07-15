using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event1 : MonoBehaviour
{
    public Conversation convo;
    private bool hasTriggered;

    void Start()
    {
        hasTriggered = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasTriggered)
        {
            DialogueManager.StartConversation(convo);
        }

        hasTriggered = true;
    }
}
