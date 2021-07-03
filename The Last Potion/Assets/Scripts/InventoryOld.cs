using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOld
{
    private List<ItemOld> itemList;

    public InventoryOld()
    {
        itemList = new List<ItemOld>();

        AddItem(new ItemOld { itemType = ItemOld.ItemType.Plant, classType = ItemOld.ClassType.Fire, value = 2});
        //Debug.Log(itemList.Count);
    }

    public void AddItem(ItemOld item)
    {
        itemList.Add(item);
    }
}
