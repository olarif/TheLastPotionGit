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

    //Choose

    public Conversation choose;

    //Too much fire

    public Conversation tooMuchFire1_1;
    public Conversation tooMuchFire1_2;
    public Conversation tooMuchFireB;
    public Conversation tooMuchFireF;
    public Conversation tooMuchFireH;
    public Conversation tooMuchFireT;
    public Conversation tooMuchFireE;

    public bool waterBottle = false;

    //Too much water

    public Conversation tooMuchWater1;
    public Conversation tooMuchWaterB;
    public Conversation tooMuchWaterF;
    public Conversation tooMuchWaterH;
    public Conversation tooMuchWaterT;
    public Conversation tooMuchWaterE;

    //Too much air

    public Conversation tooMuchAir1;
    public Conversation tooMuchAirB;
    public Conversation tooMuchAirF;
    public Conversation tooMuchAirH;
    public Conversation tooMuchAirT;
    public Conversation tooMuchAirE;

    //Too much earth

    public Conversation tooMuchEarth1;
    public Conversation tooMuchEarthB;
    public Conversation tooMuchEarthF;
    public Conversation tooMuchEarthH;
    public Conversation tooMuchEarthT;
    public Conversation tooMuchEarthE;

    //Buttons
    public Button leave;

    public void Start()
    {
        day = GameManager.instance.day;
        elementState = GameManager.instance.elementState;
        elementState = 2;

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
                //Open();
                Starter();
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
                    DialogueManager.StartConversation(tooMuchFire1_1);
                }
                else
                {
                    DialogueManager.StartConversation(tooMuchFire1_2);
                    //Choice();
                }
                break;
            case 2:
                DialogueManager.StartConversation(tooMuchWater1);
                
                break;
            case 3:
                DialogueManager.StartConversation(tooMuchAir1);
                //Choice();
                break;
            case 4:
                DialogueManager.StartConversation(tooMuchEarth1);
                Choice();
                break;

        }

        
    }

    public void checkBreath()
    {
        switch (elementState)
        {
            case 1:
                DialogueManager.StartConversation(tooMuchFireB);
                break;
            case 2:
                DialogueManager.StartConversation(tooMuchWaterB);
                Open();
                break;
            case 3:
                DialogueManager.StartConversation(tooMuchAirB);
                break;
            case 4:
                DialogueManager.StartConversation(tooMuchEarthB);
                break;

        }

        
    }

    public void checkForehead()
    {
        switch (elementState)
        {
            case 1:
                DialogueManager.StartConversation(tooMuchFireF);
                break;
            case 2:
                DialogueManager.StartConversation(tooMuchWaterF);
                Open();
                break;
            case 3:
                DialogueManager.StartConversation(tooMuchAirF);
                break;
            case 4:
                DialogueManager.StartConversation(tooMuchEarthF);
                break;

        }

        
    }

    public void checkHand()
    {
        switch (elementState)
        {
            case 1:
                DialogueManager.StartConversation(tooMuchFireH);
                break;
            case 2:
                DialogueManager.StartConversation(tooMuchWaterH);
                Open();
                break;
            case 3:
                DialogueManager.StartConversation(tooMuchAirH);
                break;
            case 4:
                DialogueManager.StartConversation(tooMuchEarthH);
                break;

        }

        
    }

    public void checkTalk()
    {
        switch (elementState)
        {
            case 1:
                DialogueManager.StartConversation(tooMuchFireT);
                break;
            case 2:
                DialogueManager.StartConversation(tooMuchWaterT);
                Open();
                break;
            case 3:
                DialogueManager.StartConversation(tooMuchAirT);
                break;
            case 4:
                DialogueManager.StartConversation(tooMuchEarthT);
                break;

        }

        
    }

    public void checkEnd()
    {
        switch (elementState)
        {
            case 1:
                DialogueManager.StartConversation(tooMuchFireE);
                break;
            case 2:
                DialogueManager.StartConversation(tooMuchWaterE);
                Open();
                break;
            case 3:
                DialogueManager.StartConversation(tooMuchAirE);
                break;
            case 4:
                DialogueManager.StartConversation(tooMuchEarthE);
                break;

        }

        
    }

    public void Choice()
    {
        DialogueManager.StartConversation(choose);
        isOpen = true;
        chatBox.SetActive(false);
        InteractWindow.SetActive(true);
        StartWindow.SetActive(true);
    }

    /*public void MentalCheck2()
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
        
    }*/

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


