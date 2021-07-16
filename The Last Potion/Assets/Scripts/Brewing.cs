using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Brewing : MonoBehaviour
{
    public GameManager manager;
    public GameObject UIInventory;
    private Inventory inventory;
    private bool inRange;

    public GameObject emptyPotion;
    public GameObject fullPotion;

    private bool hasTriggered = false;

    private int items;
    private bool potion = false;

    public Conversation potionSuccess;
    public Conversation missingItems;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public void ResetInventory()
    {
        this.inventory = new Inventory();
    }

    public void ResetPotion()
    {
        potion = false;
    }

    private void Awake()
    {
        emptyPotion.SetActive(true);
        fullPotion.SetActive(false);
    }

    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                UIInventory.SetActive(true);
            }
        }
    }

    public void Brew()
    {
        items = 0;

        foreach (Item item in inventory.GetItemList())
        {
            items++;

            Debug.Log("itemsCounter = " + items);
        }

        if (items < 4)
        {
            Debug.Log(items);
            potion = false;
            manager.SetBool(potion);
            DialogueManager.StartConversation(missingItems);
        } else if (items == 4)
        {
            Debug.Log(items);
            potion = true;
            manager.SetBool(potion);
            fullPotion.SetActive(true);
            Player.Instance.Clear();

            if (!hasTriggered)
            {
                DialogueManager.StartConversation(potionSuccess);
                hasTriggered = true;
            }
            
        }

        /*

        if (items == 4)
        {
            potion = true;
            manager.SetBool(potion);
            fullPotion.SetActive(true);
            Player.Instance.Clear();
            Debug.Log("full");
            DialogueManager.StartConversation(potionSuccess);
        }
        else if (items < 4)
        {
            potion = false;
            emptyPotion.SetActive(true);
            Debug.Log("missing");
            DialogueManager.StartConversation(missingItems);
        }

        */

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
        fullPotion.SetActive(false);
        emptyPotion.SetActive(true);
        UIInventory.SetActive(false);
    }
}