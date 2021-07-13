using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    public GameObject shelfInventory;
    public GameObject chatBox;
    private bool inRange;
    private Inventory inventory;

    public Item item1;
    public Item item2;
    public Item item3;
    public Item item4;


    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                shelfInventory.SetActive(true);
            }
        }
    }

    public void AddItem1()
    {
        if (inventory.itemList.Count < 4)
            inventory.AddItem(item1);
    }

    public void AddItem2()
    {
        if (inventory.itemList.Count < 4)
            inventory.AddItem(item2);
    }

    public void AddItem3()
    {
        if (inventory.itemList.Count < 4)
            inventory.AddItem(item3);
    }

    public void AddItem4()
    {
        if (inventory.itemList.Count < 4)
            inventory.AddItem(item4);
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        chatBox.SetActive(false);
        inRange = false;
        shelfInventory.SetActive(false);
    }
}
