using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Herb,
    Potion,
    Others
}
public enum BuffType
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

    public ItemObject(Item _item, ItemType _type, bool _stackable, string _description = "")
    {
        data = _item;
        type = _type;
        stackable = _stackable;
        description = _description;
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

    public Item(string _name, ItemBuff[] _buffs)
    {
        this.Name = _name;
        this.Buffs = _buffs;
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
                bufftype = item.data.Buffs[i].bufftype
            };
        }
    }
}

[System.Serializable]
public class ItemBuff : IModifier
{
    public BuffType bufftype;
    public int value;
    //public int min;
    //public int max;
    public ItemBuff(int _value)
    {
        value = _value;
        //GenerateValue();
    }

    public ItemBuff(int _value, BuffType _type)
    {
        value = _value;
        bufftype = _type;
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