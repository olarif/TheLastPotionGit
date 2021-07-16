using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDeactivate : MonoBehaviour
{
    public GameObject[] objects;

    public void Deativate()
    {
        foreach (GameObject objects in objects)
        {
            objects.SetActive(false);
        }
    }

    public void Reactivate()
    {
        foreach (GameObject objects in objects)
        {
            objects.SetActive(true);
        }
    }
}
