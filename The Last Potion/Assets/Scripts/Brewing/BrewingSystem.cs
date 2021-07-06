using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewingSystem: MonoBehaviour
{
    public Attribute[] attributesArray;

    public GameObject brewItButton;
    public InventoryObject brewedInventory;


    public Item item;
    public ItemObject finishedPotionObject;
    public Item finishedPotion;
    public InventorySlot finischedPotionSlot;
    public int amount;
    //private InventorySlot[,] slotAttribute = new InventorySlot[item.attribute, amount];

    public Attribute FindAttributeType(AttributeType _type)
    {
        for (int i = 0; i < attributesArray.Length; i++)
        {
            if (attributesArray[i].type == _type)
            {
                return attributesArray[i];
            }
        }
        return null;
    }
    public int GetValueOfAttribute(AttributeType _type)
    {
        Attribute _attribute = FindAttributeType(_type);
        if (_attribute == null) return 0;
        else return _attribute.value.ModifiedValue;
    }
    public void OnMouseDown()
    {
        
    }

    public void BrewPotion()
    {
        brewedInventory.AddItem(4, 1);
        DataOverWrite();
    }


    public void DataOverWrite()
    {
        if (brewedInventory.GetSlots[0].item.Id == 4)
        {
            for (int i = 0; i < attributesArray.Length; i++)
            {
                brewedInventory.GetSlots[0].item.buffs[i].value = attributesArray[i].value.ModifiedValue;
            }
        }

        finischedPotionSlot.item = finishedPotion;
        finischedPotionSlot.amount = 1;

    }
    public void BrewOutput()
    {

    }
    private void OnApplicationQuit()
    {
        brewedInventory.Clear();
    }
}
