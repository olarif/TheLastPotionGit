using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiagnoseManager : MonoBehaviour
{
    public GameObject InteractWindow;
    //public GameObject StartWindow;
    public GameObject chatBox;
    new public Transform transform;
    public int day;
    public int elementState;

    private bool isOpen;
    private bool trigger;

    //Conversations

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
            }
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
                break;
            case 3:
                DialogueManager.StartConversation(tooMuchAirE);
                break;
            case 4:
                DialogueManager.StartConversation(tooMuchEarthE);
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
        //StartWindow.SetActive(true);
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