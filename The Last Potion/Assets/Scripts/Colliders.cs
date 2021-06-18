using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Colliders : MonoBehaviour
{
    private TilemapRenderer tilemapRender;

    private void Awake()
    {
        tilemapRender = GetComponent<TilemapRenderer>();
    }

    private void Start()
    {
        tilemapRender.enabled = false;
    }

}
