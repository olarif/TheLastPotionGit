using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Herb,
    Potion,
    Others
}
public enum AttributeType
{
    fireValue,
    earthValue,
    waterValue,
    airValue
}
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/Items/item")]
public class ItemObject : ScriptableObject
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
    public int Id = -1;
    public ItemBuff[] Buffs;
    public Item()
    {
        Name = "";
        Id = -1;
    }
    public Item(string _name, ItemBuff[] buffs)
    {
        this.Name = _name;
        for (int i = 0; i < Buffs.Length; i++)
        {
            //for (int j = 0; j < ; j++)
            //{
            //    if (Buffs[i].attribute = buffs[i].attribute)
            //        this.Buffs[i].value = buffs[i].value;

            //}

        }
    }
    public Item(ItemObject item)
    {
        Name = item.name;
        Id = item.data.Id;
        Buffs = new ItemBuff[item.data.Buffs.Length];
        for (int i = 0; i < Buffs.Length; i++)
        {
            Buffs[i] = new ItemBuff(item.data.Buffs[i].value)
            {
                attribute = item.data.Buffs[i].attribute
            };
        }
    }
}
[System.Serializable]
public class ItemBuff : IModifier
{
    public AttributeType attribute;
    public int value;
    //public int min;
    //public int max;
    public ItemBuff(int _value)
    {
        value = _value;
        //GenerateValue();
    }

    public void AddValue(ref int baseValue)
    {
        baseValue += value ;
    }
    //public void GenerateValue()
    //{
    //    value = UnityEngine.Random.Range(min, max);
    //}
}