using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WifeStateManager : MonoBehaviour
{
    public static WifeStateManager instance;
    public int elementState;

    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        elementState = 1;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
