using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiagnoseManager : MonoBehaviour
{
    public GameObject InteractWindow;
    public GameObject StartWindow;
    public GameObject chatBox;
    new public Transform transform;
    public int day;

    private bool isOpen;
    private bool trigger;

    //Conversations

    //Too much water

    public Conversation tooMuchFire1;
    public Conversation tooMuchFire2;
    public Conversation Physical1;
    public Conversation Physical2;
    public Conversation Mental1;
    public Conversation Mental2;

    //Buttons
    public Button leave;

    public void Start()
    {
        day = GameManager.instance.day;

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
    }


    public void PhysicalCheck1()
    {
        switch (day)
        {
            case 1:
                DialogueManager.StartConversation(tooMuchFire1);
                break;
            case 2:
                DialogueManager.StartConversation(tooMuchFire2);
                break;
        }


        DialogueManager.StopConversation();
        DialogueManager.StartConversation(Physical1);
    }

    public void PhysicalCheck2()
    {
        DialogueManager.StopConversation();
        DialogueManager.StartConversation(Physical2);
    }

    public void MentalCheck1()
    {
        DialogueManager.StartConversation(Mental1);
    }

    public void MentalCheck2()
    {
        switch (day){
            case 1:
                Debug.Log("Mental 2: Day 1");
                //DialogueManager.StartConversation(Mental1);
                break;
            case 2:
                Debug.Log("Mental 2: Day 2");
                //DialogueManager.StartConversation(Mental2);
                break;
        }
        
    }

    public void EndConvo()
    {
        DialogueManager.StopConversation();
    }

    public void Close()
    {
        trigger = false;
        isOpen = false;

        foreach (Transform child in transform)
            child.gameObject.SetActive(false);

        InteractWindow.SetActive(false);
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
        trigger = true;
        chatBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        chatBox.SetActive(false);
        Close();
    }
}






/*
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



public void Observe()
{
    if (DialogueManager.instance.currentIndex == 0)
    {
        Close();
        DialogueManager.StartConversation(observe);
    }

    if (DialogueManager.instance.currentIndex > DialogueManager.instance.currentConvo.GetLength() - 1)
    {
        Open();
    }
}

public void Feeling()
{
    Close();
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

*/


