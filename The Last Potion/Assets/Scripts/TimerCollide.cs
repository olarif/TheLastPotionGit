using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class TimerCollide : MonoBehaviour
{
    public float timer;
    public UnityEvent OnDialogueEnd;
    private bool triggered;


    private void Update()
    {
        if (triggered)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        triggered = false;
    }
}
