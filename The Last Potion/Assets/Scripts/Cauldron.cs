using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cauldron : MonoBehaviour
{
    public GameObject chatBox;
    public GameObject uiInventory;
    private bool inRange;
    private GameObject player;
    private Inventory inventory;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                uiInventory.SetActive(!uiInventory.activeInHierarchy);

                foreach (Item item in inventory.GetItemList())
                {
                    if (item.itemType == Item.ItemType.Plant1)
                    {
                        Debug.Log("you found one!");
                    } else
                    {
                        Debug.Log("sorry you dont have the item");
                    }
                }
            }
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
        //inventory.SetActive(!inventory.activeInHierarchy);
    }
}

