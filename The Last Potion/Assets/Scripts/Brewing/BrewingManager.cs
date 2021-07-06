using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewingManager : MonoBehaviour
{
    private bool isOpen;
    //private bool trigger;
    public GameObject chatBox;
    public InventoryObject preparation;

    public Attribute[] attributesArray;

    private void Start()
    {
        for (int i = 0; i < attributesArray.Length; i++)
        {
            attributesArray[i].SetParent(this);
        }
        for (int i = 0; i < preparation.GetSlots.Length; i++)
        {
            preparation.GetSlots[i].OnBeforeUpdate += OnRemoveItem;
            preparation.GetSlots[i].OnAfterUpdate += OnAddItem;

        }
    }

    public void OnRemoveItem(InventorySlot _slot)
    {
        if (_slot.itemObject == null)
            return;
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Preparation:
                print(string.Concat("Removed ", _slot.itemObject, " on ", _slot.parent.inventory.type, ", Allowed Items: ", string.Join(", ", _slot.AllowedItems)));

                for (int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for (int j = 0; j < attributesArray.Length; j++)
                    {
                        if (attributesArray[j].type == _slot.item.buffs[i].attribute)
                            attributesArray[j].value.RemoveModifier(_slot.item.buffs[i], _slot.amount);
                    }
                }
                break;
            case InterfaceType.Brewed:
                break;
            default:
                break;
        }
    }
    public void OnAddItem(InventorySlot _slot)
    {
        if (_slot.itemObject == null)
            return;
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Preparation:
                print(string.Concat("Placed ", _slot.itemObject, " on ", _slot.parent.inventory.type, ", Allowed Items: ", string.Join(", ", _slot.AllowedItems)));

                for (int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for (int j = 0; j < attributesArray.Length; j++)
                    {
                        if (attributesArray[j].type == _slot.item.buffs[i].attribute)
                            attributesArray[j].value.AddModifier(_slot.item.buffs[i], _slot.amount);
                    }
                }
                
                break;
            case InterfaceType.Brewed:
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //trigger = true;
        chatBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        chatBox.SetActive(false);
    }

    public void AttributeModified(Attribute attribute)
    {
        Debug.Log(string.Concat(attribute.type, " was updated! Value is now ", attribute.value.ModifiedValue));
    }
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
}
public delegate void AttributeDisplayUpdated(Attribute _attribute);
[System.Serializable]
public class Attribute
{
    public AttributeType type;
    [System.NonSerialized]
    public BrewingManager parent1;
    [System.NonSerialized]
    public BrewingDisplay parent2;
    [System.NonSerialized]
    public GameObject attributeDisplay;
    [System.NonSerialized]
    public AttributeDisplayUpdated OnAfterUpdate;
    [System.NonSerialized]
    public AttributeDisplayUpdated OnBeforeUpdate;
    public ModifiableInt value;

    public void SetParent(BrewingManager _parent)
    {
        parent1 = _parent;
        value = new ModifiableInt(AttributeModified);
    }
    public void AttributeModified()
    {
        parent1.AttributeModified(this);
    }

    public Attribute(ModifiableInt _value)
    {
        UpdateAttribute(_value);
    }
    public void UpdateAttribute(ModifiableInt _value)
    {
        if (OnBeforeUpdate != null)
            OnBeforeUpdate.Invoke(this);
        value = _value;
        if (OnAfterUpdate != null)
            OnAfterUpdate.Invoke(this);
    }

}
