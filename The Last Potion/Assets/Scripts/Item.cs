using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Plant,
        Other,
    }

    public enum ClassType
    {
        Fire,
        Earth,
        Water,
        Air,
    }

    public ItemType itemType;
    public ClassType classType;
    public int value;
}

