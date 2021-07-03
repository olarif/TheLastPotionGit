using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Herbs Object", menuName = "Inventory Items/Herbs")]
public class HerbsObject : ItemScriptableObject
{

    public void Awake()
    {
        type = ItemType.Herbs;
    }

}
