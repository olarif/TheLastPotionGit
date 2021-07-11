using System.Collections;
using UnityEngine;
using Cinemachine;

public class Teleport : MonoBehaviour
{
    public GameObject Portal;
    public GameObject Player;

    [SerializeField] private CinemachineVirtualCamera room1Cam; // World
    [SerializeField] private CinemachineVirtualCamera room2Cam; // First Floor
    [SerializeField] private CinemachineVirtualCamera room3Cam; // Bedroom

    private int room;

    private bool worldCam = true;
    private bool bedroomCam;

    private void Awake()
    {
        room = 1;
    }

    private void SwitchPriority()
    {
        if (room == 1)  // world
        {
            room1Cam.Priority = 1;
            room2Cam.Priority = 0;
            room3Cam.Priority = 0;
        } 
        else if(room == 2)  // first floor
        {
            room1Cam.Priority = 0;
            room2Cam.Priority = 1;
            room3Cam.Priority = 0;
        }
        else if (room == 3)  // bedroom
        {
            room1Cam.Priority = 0;
            room2Cam.Priority = 0;
            room3Cam.Priority = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.tag == "Room1")
        {
            room = 2;
            Debug.Log("Room1");
        } 
        else if (this.tag == "Room2")
        {
            room = 3;
            Debug.Log("Room2");
        }
        else if (this.tag == "Room3")
        {
            room = 2;
        }
        else if (this.tag == "Door")
        {
            room = 1;
        }

        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(TeleportPlayer());
        }
    }

    private IEnumerator TeleportPlayer()
    {
        yield return new WaitForSeconds (.5f);
        Player.transform.position = new Vector2(Portal.transform.position.x, Portal.transform.position.y);
        SwitchPriority();
    }
}
                                