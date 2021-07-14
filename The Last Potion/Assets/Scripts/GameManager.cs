using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState {  FreeRoam, Dialogue}

    public static GameManager instance;
    public int day;

    [SerializeField] Player playerController;

    public GameObject UIwindow;

    public GameState state;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        day = 1;

        state = GameState.FreeRoam;
    }

    public void Update()
    {

        if (!DialogueManager.instance.isActive && Input.GetKeyDown(KeyCode.I))
        {
            UIwindow.SetActive(!UIwindow.activeInHierarchy);
        }

        if (DialogueManager.instance.isActive)
        {
            state = GameState.Dialogue;
        } else
        {
            state = GameState.FreeRoam;
        }


        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        } 
        else if (state == GameState.Dialogue)
        {
            playerController.StopWalking();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
