using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToWife : MonoBehaviour
{
    public GameObject chatBubble;
    public Conversation potionTrue;
    public Conversation potionFalse;
    private Cauldron cauldron;
    private bool inRange;
    private bool inProgress = false;
    public bool potionBool;

    public void SetBool(bool potion)
    {
        this.potionBool = potion;
    }

    private void Update()
    {

        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && !inProgress)
            {
                if (potionBool)
                {
                    DialogueManager.StartConversation(potionTrue);
                    inProgress = true;
                }
                else
                {
                    DialogueManager.StartConversation(potionFalse);
                    inProgress = true;
                }
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
