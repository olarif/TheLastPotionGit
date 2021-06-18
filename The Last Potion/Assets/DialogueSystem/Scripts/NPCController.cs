using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    public Conversation convo;
    public GameObject chatBox;


    public void Interact()
    {
        if (!DialogueManager.isOpen)
        {
            chatBox.SetActive(false);
            DialogueManager.StartConversation(convo);
        } 
        else if (DialogueManager.isOpen)
        {
            DialogueManager.instance.ReadNext();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            chatBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            chatBox.SetActive(false);
            DialogueManager.StopConversation();
        }
    }
}
