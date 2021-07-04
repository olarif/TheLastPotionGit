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
    public void AddItem(Item _item, int _amount)
    {
        
        
        for (int i = 0; i < Container.itemList.Length; i++)
        {
            if (Container.itemList[i].ID == _item.Id)
            {
                Container.itemList[i].AddAmount(_amount);
                return;
            }
        }
        SetEmptySlot(_item, _amount);
        
    }
    public InventorySlot SetEmptySlot(Item _item, int _amount)
    {
        for (int i = 0; i < Container.itemList.Length; i++)
        {
            if(Container.itemList[i].ID <= -1)
            {
                Container.itemList[i].UpdateSlot(_item.Id, _item, _amount);
                return Container.itemList[i];
            }
        }
        //set up function
        return null;
    }

    public void MoveItem(InventorySlot item1, InventorySlot item2)
    {
        InventorySlot temp = new InventorySlot(item2.ID, item2.item, item2.amount);
        item2.UpdateSlot(item1.ID, item1.item, item1.amount);
        item1.UpdateSlot(temp.ID, temp.item, temp.amount);
    }
    
    public void RemoveItem(Item _item)
    {
        for (int i = 0; i < Container.itemList.Length; i++)
        {
            if (Container.itemList[i].item == _item)
            {
                Container.itemList[i].UpdateSlot(-1, null, 0);
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
        Container = new Inventory();
    }

}
[System.Serializable]
public class Inventory
{
    public InventorySlot[] itemList = new InventorySlot[20];
}

[System.Serializable]
public class InventorySlot
{
    public UserInterface parent;
    public int ID;
    public Item item;
    public int amount;
    public InventorySlot()
    {
        ID = -1;
        item = null;
        amount = 0;
    }
    public InventorySlot(int _id, Item _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }
    public void UpdateSlot(int _id, Item _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }

}