using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Cauldron : MonoBehaviour
{
    public GameManager manager;

    public GameObject chatBox;
    public GameObject brewingInventory;
    public GameObject UIInventory;
    private GameObject player;
    private Inventory inventory;
    private bool inRange;

    public GameObject emptyPotion;
    public GameObject fullPotion;

    private int items;
    private int itemTypes;
    private bool potion = false;

    public Conversation potionSuccess;
    public Conversation missingItems;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    private void Awake()
    {
        items = 0;
        itemTypes = 0;

        potion = false;

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
                brewingInventory.SetActive(true);
            }
        }
    }

    public void Brew()
    {
        items = 0;
        itemTypes = 0;

        foreach (Item item in inventory.GetItemList())
        {
            items++;
        }

        foreach (Item itemType in inventory.GetItemList())
        {
            itemTypes++;
        }

        switch (items)
        {
            default:
            case 1:
                potion = false;
                manager.SetBool(potion);
                DialogueManager.StartConversation(missingItems);
                break;
            case 2:
                potion = false;
                manager.SetBool(potion);
                DialogueManager.StartConversation(missingItems);
                break;
            case 3:
                potion = false;
                manager.SetBool(potion);
                DialogueManager.StartConversation(missingItems);
                break;
            case 4:
                Player.Instance.Clear();
                fullPotion.SetActive(true);
                DialogueManager.StartConversation(potionSuccess);
                potion = true;
                manager.SetBool(potion);
                break;
        }

        switch (itemTypes)
        {
            default:
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        chatBox.SetActive(true);
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        chatBox.SetActive(false);
        inRange = false;
        fullPotion.SetActive(false);
        emptyPotion.SetActive(true);
        UIInventory.SetActive(false);
        brewingInventory.SetActive(false);
    }
}

