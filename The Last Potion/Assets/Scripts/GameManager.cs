using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public enum GameState {  FreeRoam, Dialogue}

    public static GameManager instance;
    public bool potionBool;
    public GameObject UIwindow;
    public GameState state;

    [SerializeField] Player playerController;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        state = GameState.FreeRoam;
    }

    public void Update()
    {

        if (DialogueManager.instance.isActive && Input.GetKeyDown(KeyCode.Space))
        {
            DialogueManager.instance.ReadNext();
        }


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

    public void Teleport(float x, float y, float z)
    {
        
    }

    public void DisableMovement()
    {
        state = GameState.Dialogue;
    }

    public void EnableMovement()
    {
        state = GameState.FreeRoam;
    }

    public void ClearPotion()
    {
        this.potionBool = false;
    }

    public void SetBool(bool potion)
    {
        this.potionBool = potion;
    }
}
