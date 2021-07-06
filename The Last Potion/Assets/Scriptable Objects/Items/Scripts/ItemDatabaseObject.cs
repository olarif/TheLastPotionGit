using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Items/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] ItemsArray;
    //public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>();

    [ContextMenu("Update ID's")]
    public void UpdateID()
    {
        for (int i = 0; i < ItemsArray.Length; i++)
        {
            if (ItemsArray[i].data.Id != i)
                ItemsArray[i].data.Id = i;
        }
    }

    public void OnAfterDeserialize()
    {
        UpdateID();
        //for (int i = 0; i < ItemsArray.Length; i++)
        //{
        //    ItemsArray[i].data.Id = i;
        //    GetItem.Add(i, ItemsArray[i]);
        //}
    }

    public void OnBeforeSerialize()
    {
        //GetItem = new Dictionary<int, ItemObject>();
    }
}
