using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayer : MonoBehaviour
{
    //public GameObject spriteHolder;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        spriteHolder = GameObject.Find("PrefabHolder");

        foreach (SpriteRenderer sprite in spriteHolder.GetComponentInChildren())
        {
            items++;

            Debug.Log("itemsCounter = " + items);
        }

        */

        sprite.sortingOrder = 6;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //sprite.sortingOrder = 6;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sprite.sortingOrder = 4;
    }
}
