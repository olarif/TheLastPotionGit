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
    public int elementState;
    //elementState == 1 --> too much fire
    //elementState == 2 --> too much water
    //elementState == 3 --> too much air
    //elementState == 4 --> too much earth

    private bool isOpen;
    private bool trigger;

    //Conversations

    //Too much fire

    public Conversation tooMuchFire1;
    public Conversation tooMuchFire2;
    public Conversation tooMuchFire3;
    public Conversation tooMuchFire4;
    public Conversation tooMuchFire5;
    public Conversation tooMuchFire6;

    public bool waterBottle = false;

    //Too much water

    public Conversation tooMuchWater1;
    public Conversation tooMuchWater2;
    public Conversation tooMuchWater3;
    public Conversation tooMuchWater4;
    public Conversation tooMuchWater5;
    public Conversation tooMuchWater6;

    //Too much air

    public Conversation tooMuchAir1;
    public Conversation tooMuchAir2;
    public Conversation tooMuchAir3;
    public Conversation tooMuchAir4;
    public Conversation tooMuchAir5;
    public Conversation tooMuchAir6;

    //Too much earth

    public Conversation tooMuchEarth1;
    public Conversation tooMuchEarth2;
    public Conversation tooMuchEarth3;
    public Conversation tooMuchEarth4;
    public Conversation tooMuchEarth5;
    public Conversation tooMuchEarth6;

    //Buttons
    public Button leave;

    public void Start()
    {
        day = GameManager.instance.day;
        elementState = GameManager.instance.elementState;

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
                //Starter();
            }
        }
    }

    public void Starter()
    {
        //Open();
        switch ( elementState )
        {
            case 1:
                if (waterBottle == false)
                {
                    DialogueManager.StartConversation(tooMuchFire1);
                }
                else
                {
                    DialogueManager.StartConversation(tooMuchFire2);
                }
                break;
            case 2:
                DialogueManager.StartConversation(tooMuchWater1);
                break;
            case 3:
                DialogueManager.StartConversation(tooMuchAir1);
                break;
            case 4:
                DialogueManager.StartConversation(tooMuchEarth1);
                break;

        }
        DialogueManager.StopConversation();
        
    }

    public void PhysicalCheck1()
    {
        switch (elementState)
        {
            case 1:
                DialogueManager.StartConversation(tooMuchWater1);
                break;
            case 2:
                DialogueManager.StartConversation(tooMuchWater2);
                break;
        }


        DialogueManager.StopConversation();
        DialogueManager.StartConversation(tooMuchWater2);
    }

    public void PhysicalCheck2()
    {
        DialogueManager.StopConversation();
        DialogueManager.StartConversation(tooMuchWater2);
    }

    public void MentalCheck1()
    {
        DialogueManager.StartConversation(tooMuchWater2);
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


