using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene1 : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("Scene2");
    }
}
