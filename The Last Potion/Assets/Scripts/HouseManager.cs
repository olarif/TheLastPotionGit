using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        player.transform.position = new Vector2(8, -3);
    }

    void Update()
    {

    }
}
