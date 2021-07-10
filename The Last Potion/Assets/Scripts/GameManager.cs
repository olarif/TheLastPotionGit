using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState {  FreeRoam, Dialogue}

    public static GameManager instance;
    public int day;
    public int elementState;

    [SerializeField] Player playerController;

    public GameObject UIwindow;

    GameState state;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        day = 2;
        elementState = 1;

        state = GameState.FreeRoam;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            UIwindow.SetActive(!UIwindow.activeInHierarchy);
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
