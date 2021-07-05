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
            preparation.GetSlots[i].OnBeforeUpdate += OnBeforeSlotUpdate;
            preparation.GetSlots[i].OnAfterUpdate += OnAfterSlotUpdate;

        }
    }

    public void OnBeforeSlotUpdate(InventorySlot _slot)
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
                            attributesArray[j].value.RemoveModifier(_slot.item.buffs[i]);
                    }
                }
                break;
            case InterfaceType.Brewed:
                break;
            default:
                break;
        }
    }
    public void OnAfterSlotUpdate(InventorySlot _slot)
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
                            attributesArray[j].value.AddModifier(_slot.item.buffs[i]);
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
}
[System.Serializable]
public class Attribute
{
    [System.NonSerialized]
    public BrewingManager parent;
    public Attributes type;
    public ModifiableInt value;

    public void SetParent(BrewingManager _parent)
    {
        parent = _parent;
        value = new ModifiableInt(AttributeModified);
    }
    public void AttributeModified()
    {
        parent.AttributeModified(this);
    }

}
