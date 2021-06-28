using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState {  FreeRoam, Dialogue}

    private Inventory inventory;

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

        day = 2;

        state = GameState.FreeRoam;

        inventory = new Inventory();
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
