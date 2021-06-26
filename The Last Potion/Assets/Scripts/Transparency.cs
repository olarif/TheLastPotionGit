using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency : MonoBehaviour
{
    private SpriteRenderer sprite;
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        sprite.color = new Color(1, 1, 1, .3f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sprite.color = new Color(1, 1, 1, 1f);
    }
}
