using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    public Conversation convo;

    //Day 1
    //Randomize wifes feelings

    //


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            DialogueManager.StartConversation(convo);
        }
    }
}
