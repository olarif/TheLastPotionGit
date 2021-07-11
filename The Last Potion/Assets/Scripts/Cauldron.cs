using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Cauldron : MonoBehaviour
{
    public GameObject chatBox;
    public GameObject brewingInventory;
    private bool inRange;
    private GameObject player;
    private Inventory inventory;

    public Sprite emptyPotion;
    public Sprite fullPotion;
    public Image image;

    private int items;
    private int itemTypes;

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
    }

    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
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
                DialogueManager.StartConversation(missingItems);
                break;
            case 2:
                DialogueManager.StartConversation(missingItems);
                break;
            case 3:
                DialogueManager.StartConversation(missingItems);
                break;
            case 4:
                Player.Instance.Clear();
                image.sprite = fullPotion;
                DialogueManager.StartConversation(potionSuccess);
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
        image.sprite = emptyPotion;
        brewingInventory.SetActive(false);
    }
}

