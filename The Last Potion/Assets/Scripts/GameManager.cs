using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState {  FreeRoam, Dialogue}

    public GameObject image;
    private bool toggle = false;

    public static GameManager instance;
    public int day;

    [SerializeField] PlayerMovement playerController;

    GameState state;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        day = 1;

        state = GameState.FreeRoam;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            toggle = !toggle;

            image.SetActive(toggle);
        }

        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        } 
        else if (state == GameState.Dialogue)
        {

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
