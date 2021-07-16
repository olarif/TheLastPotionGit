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

    private int items;
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
            }
        }
    }

    public void Brew()
    {
        items = 0;

        foreach (Item item in inventory.GetItemList())
        {
            items++;
        }

        if (items == 4)
        {
            potion = true;
            manager.SetBool(potion);
            fullPotion.SetActive(true);
            Player.Instance.Clear();
            DialogueManager.StartConversation(potionSuccess);
        } else
        {
            potion = false;
            emptyPotion.SetActive(true);
            DialogueManager.StartConversation(missingItems);
        }

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