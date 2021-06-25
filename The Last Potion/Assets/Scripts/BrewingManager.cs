using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewingManager : MonoBehaviour
{
    private bool isOpen;
    private bool trigger;
    public GameObject chatBox;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        trigger = true;
        chatBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        chatBox.SetActive(false);
    }
}
