using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Desk : MonoBehaviour
{
    public PlayableDirector deskScene;
    public GameObject chatBox;
    private bool inRange;
    private bool hasTriggered = false;

    public void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            chatBox.SetActive(false);
            deskScene.Play();
            hasTriggered = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
        chatBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
        chatBox.SetActive(false);
    }
}
