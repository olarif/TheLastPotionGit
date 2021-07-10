using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{

    public static ItemAssets Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    public Sprite plant1Sprite;
    public Sprite plant2Sprite;
    public Sprite plant3Sprite;
    public Sprite plant4Sprite;
}
