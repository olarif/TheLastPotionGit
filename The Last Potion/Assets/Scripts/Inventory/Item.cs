using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemType
    {
        Plant1,
        Plant2,
        Plant3,
        Plant4,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Plant1: return ItemAssets.Instance.plant1Sprite;
            case ItemType.Plant2: return ItemAssets.Instance.plant2Sprite;
            case ItemType.Plant3: return ItemAssets.Instance.plant3Sprite;
            case ItemType.Plant4: return ItemAssets.Instance.plant4Sprite;
        }
    }

    public Color GetColor()
    {
        switch (itemType)
        {
            default:
                //blue
            case ItemType.Plant1: return new Color(0, 0, 1);
                //white
            case ItemType.Plant2: return new Color(1, 1, 1);
                //yellow
            case ItemType.Plant3: return new Color(1, 0.92f, 0.016f);
                //red
            case ItemType.Plant4: return new Color(1, 0, 0);
        }
    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.Plant1:
                return false;
            case ItemType.Plant2:
                return false;
            case ItemType.Plant3:
                return true;
            case ItemType.Plant4:
                return true;
        }
    }
}

