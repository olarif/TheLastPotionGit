using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingInventory : MonoBehaviour
{
    InventoryObject bookInventory;



    [System.Serializable]
    public struct StartingItem
    {
        public ItemObject itemObject;
        public int amount;
    }
    // Start is called before the first frame update
    void Start()
    {
        //InventoryObject bookInventory = PlayerMovement;

        //foreach (StartingItem startingItem in startingItemArray)
        //{
        //    bookInventory.AddItem(
        //        new Item
        //        {
        //            itemObject = startingItem.itemObject,
        //            amount = startingItem.amount
        //        }
        //}
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
