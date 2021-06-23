using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Pass in the curretn day and change the output depending on whihc day it is Observe(day1);
//if day 2 -> different convo called


public class DiagnoseManager : MonoBehaviour
{
    public GameObject InteractWindow;
    public GameObject StartWindow;
    public GameObject DiagnoseWindow;

    public GameObject chatBox;

    public Conversation talk;
    public Conversation feeling;
    public Conversation observe;

    [HideInInspector] public bool isOpen;
    private bool trigger;

    public void Start()
    {
        trigger = false;
        chatBox.SetActive(false);
        InteractWindow.SetActive(false);
    }

    public void Update()
    {
        if (!isOpen && trigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Open();
            }
        }


        if (isOpen)
        {
            if (StartWindow.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Close();
                    DialogueManager.StartConversation(talk);
                }

                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    StartWindow.SetActive(false);
                    DiagnoseWindow.SetActive(true);
                }

                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    Close();
                }
            }

            else if (DiagnoseWindow.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Observe();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    Feeling();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    Close();
                }
            }
        }
    }

    public void Observe()
    {
        Close();
        DialogueManager.StartConversation(observe);
    }

    public void Feeling()
    {
        Close();
        DialogueManager.StartConversation(feeling);
    }

    public void Close()
    {
        trigger = false;
        isOpen = false;

        InteractWindow.SetActive(false);
        StartWindow.SetActive(false);
        DiagnoseWindow.SetActive(false);
    }

    public void Open()
    {
        isOpen = true;
        chatBox.SetActive(false);
        InteractWindow.SetActive(true);
        StartWindow.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            trigger = true;
            chatBox.SetActive(true);
        }
    }

    /*

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("triggering");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Press e");
                Open();
            }
        }
    }

    */

    private void OnTriggerExit2D(Collider2D collision)
    {
        chatBox.SetActive(false);
        Close();
    }
}


