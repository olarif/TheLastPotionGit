using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    public GameObject uiInventory;
    public GameObject chatBox;
    private bool inRange;
    private Inventory inventory;

    public Item item1;
    public Item item2;
    public Item item3;

    void Start()
    {
        
    }

    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if ( inventory.itemList.Count < 4)
                {
                    inventory.AddItem(item1);
                }
            } else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (inventory.itemList.Count < 4)
                {
                    inventory.AddItem(item2);
                }
            } else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (inventory.itemList.Count < 4)
                {
                    inventory.AddItem(item3);
                }
            }
        }
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        chatBox.SetActive(true);
        inRange = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        chatBox.SetActive(true);
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        chatBox.SetActive(false);
        inRange = false;
    }
}
