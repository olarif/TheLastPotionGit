using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState {  FreeRoam, Dialogue}


    public static GameManager instance;
    public int day;
    public int elementState;

    [SerializeField] PlayerMovement playerController;

    GameState state;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        day = 2;
        elementState = 1;

        state = GameState.FreeRoam;

    }

    public void Update()
    {

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
