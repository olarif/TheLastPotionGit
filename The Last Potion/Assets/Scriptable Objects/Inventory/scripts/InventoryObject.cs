using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public string savePath;
    public ItemDatabaseObject database;
    public Inventory Container;

    
    public void AddItem(int _itemId, int _amount)
    {
        Item _item = new Item(database.Items[_itemId]);
        AddItem(_item, _amount);
    }
    public bool AddItem(Item _item, int _amount)
    {
        if (EmptySlotCount <= 0)
            return false;
        InventorySlot slot = FindItemOnInventory(_item);
        if(!database.GetItem[_item.Id].stackable || slot == null)
        {
            SetEmptySlot(_item, _amount);
            return true;
        }
        slot.AddAmount(_amount);
        return true;
    }
    public int EmptySlotCount
    {
        get
        {
            int counter = 0;
            for (int i = 0; i < Container.slotArray.Length; i++)
            {
                if (Container.slotArray[i].item.Id <= -1)
                    counter++;
            }
            return counter;
        }
    }
    public InventorySlot FindItemOnInventory(Item _item)
    {
        for (int i = 0; i < Container.slotArray.Length; i++)
        {
            if (Container.slotArray[i].item.Id == _item.Id)
            {
                return Container.slotArray[i];
            }
        }
        return null;
    }
    public InventorySlot SetEmptySlot(Item _item, int _amount)
    {
        for (int i = 0; i < Container.slotArray.Length; i++)
        {
            if(Container.slotArray[i].item.Id <= -1)
            {
                Container.slotArray[i].UpdateSlot(_item, _amount);
                return Container.slotArray[i];
            }
        }
        //set up function
        return null;
    }

    public void SwapItems(InventorySlot slot1, InventorySlot slot2)
    {
        if (slot2.CanPlaceIn(slot1.ItemObject_) && slot1.CanPlaceIn(slot2.ItemObject_))
        {
            InventorySlot temp = new InventorySlot(slot2.item, slot2.amount);
            slot2.UpdateSlot(slot1.item, slot1.amount);
            slot1.UpdateSlot(temp.item, temp.amount);

        }
    }
    
    public void RemoveItem(Item _item)
    {
        for (int i = 0; i < Container.slotArray.Length; i++)
        {
            if (Container.slotArray[i].item == _item)
            {
                Container.slotArray[i].UpdateSlot(null, 0);
            }
        }
    }

    [ContextMenu("Save")]
    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }
    [ContextMenu("Load")]
    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savePath))){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        Container.Clear();
    }

}
[System.Serializable]
public class Inventory
{
    public InventorySlot[] slotArray = new InventorySlot[20];
    public void Clear()
    {
        for (int i = 0; i < slotArray.Length; i++)
        {
            slotArray[i].RemoveItem();
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemType[] AllowedItems = new ItemType[0];
    [System.NonSerialized]
    public UserInterface parent;
    public Item item;
    public int amount;

    public ItemObject ItemObject_
    {
        get
        {
            if (item.Id >= 0)
            {
                return parent.inventory.database.GetItem[item.Id];
            }
            return null;
        }
    }
    public InventorySlot()
    {
        item = new Item();
        amount = 0;
    }
    public InventorySlot(Item _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }
    public void RemoveItem()
    {
        item = new Item();
        amount = 0;
    }
    public void UpdateSlot(Item _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
    public bool CanPlaceIn(ItemObject _itemObject)
    {
        if (AllowedItems.Length <= 0 || _itemObject == null || _itemObject.data.Id < 0)
            return true;
        for (int i = 0; i < AllowedItems.Length; i++)
        {
            if (_itemObject.type == AllowedItems[i])
                return true;
        }
        return false;
    }
}