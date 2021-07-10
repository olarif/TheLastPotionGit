using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewingSystem: MonoBehaviour
{
    public Attribute[] attributesArray;

    public GameObject brewItButton;
    public InventoryObject BeforeInv;
    public InventoryObject AfterInv;


    private Item item;
    private Item finishedPotion;
    private InventorySlot finischedPotionSlot;
    public int amount = 1;
    //private InventorySlot[,] slotAttribute = new InventorySlot[item.attribute, amount];

    public Attribute FindAttributeType(BuffType _type)
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

    public int GetValueOfAttribute(BuffType _type)
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
        //Calculate the values for each buff attribute

        //Pseudo: fireAttributeValue = (slot[0].item.Buffs[0].Value * slot[0].amount) + (slot[1].item.Buffs[0].Value * slot[1].amount)

        //Item newPotionBlueprint = new Item(name, firevalue, watervalue, )

        //ItemObject newPotionObject = new ItemObject(newPotiobBlueprint, ItemType.Potion, false, "Procedural description");

        AfterInv.AddItem(4, 1);
        //DataOverWrite();
        BeforeInv.Clear();
        
        
    }


    public void DataOverWrite()
    {
        if (AfterInv.GetSlots[0].item.Id == 4)
        {
            for (int i = 0; i < attributesArray.Length; i++)
            {
                AfterInv.GetSlots[0].item.Buffs[i].value = attributesArray[i].value.ModifiedValue;
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
        AfterInv.Clear();
    }
}
