using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Outdoor : MonoBehaviour
{
    AudioManager ManagerRef;

    // Start is called before the first frame update
    void Start()
    {
        ManagerRef = GetComponentInParent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ManagerRef.StartMusicOutdoor();
    }
}
