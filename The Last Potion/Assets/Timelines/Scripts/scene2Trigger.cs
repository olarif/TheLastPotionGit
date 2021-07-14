using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class scene2Trigger : MonoBehaviour
{
    public PlayableDirector scene2;
    public GameObject chatBubble;
    private bool inRange;

    public GameObject shelfInventory;
    private Inventory inventory;

    public Item item1;
    public Item item2;
    public Item item3;
    public Item item4;

    public void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            //shelfInventory.SetActive(true);
            chatBubble.SetActive(false);
            scene2.Play();
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
        inRange = true;
        chatBubble.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
        chatBubble.SetActive(false);
        shelfInventory.SetActive(false);
    }
}
