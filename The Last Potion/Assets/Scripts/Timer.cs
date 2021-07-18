using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Timer : MonoBehaviour
{
    public float timer;
    public UnityEvent OnDialogueEnd;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (!DialogueManager.instance.isActive)
            {
                OnDialogueEnd.Invoke();
            }
        }

    }
}
