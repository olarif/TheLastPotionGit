using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_FirstFloor : MonoBehaviour
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
        ManagerRef.StartMusicFirstFloor();

        /*Debug.Log("Test_Outer_Collision");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Test_Inner_Collision");
        }*/
    }
}
