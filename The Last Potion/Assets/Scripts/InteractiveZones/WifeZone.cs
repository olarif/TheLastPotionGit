using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WifeZone : MonoBehaviour
{
    public GameObject chatBox;
    private bool inRange;

    public void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            chatBox.SetActive(false);
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
