using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Herb,
    Potion,
    Others
}
public enum Attributes
{
    fireValue, 
    waterValue,
    airValue,
    earthValue
}
public abstract class ItemObject : ScriptableObject
{
    public Sprite uiDisplay;
    public bool stackable;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
    public Item data = new Item();

    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}

[System.Serializable]
public class Item
{
    public string Name;
    public int Id;
    public ItemBuff[] buffs;
    public Item()
    {
        Name = "";
        Id = -1;
    }
    public Item(ItemObject item)
    {
        Name = item.name;
        Id = item.data.Id;
        buffs = new ItemBuff[item.data.buffs.Length];
        for (int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff()
            {
                attribute = item.data.buffs[i].attribute
            };
        }
    }
}
[System.Serializable]
public class ItemBuff
{
    public Attributes attribute;
    public float value;
}