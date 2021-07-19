using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Footsteps : MonoBehaviour
{
    // FMOD Isntance
    private FMOD.Studio.EventInstance IFootsteps;

    private void Start()
    {
        // Footsteps
        IFootsteps = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Footsteps_Wood");
        IFootsteps.start();
    }

    private void Update()
    {
        if (Input.GetAxis("Vertical") >= 0.01f || Input.GetAxis("Horizontal") >= 0.01f || Input.GetAxis("Vertical") <= -0.01f || Input.GetAxis("Horizontal") <= -0.01f)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("isWalking", 1f);

        }
        else if (Input.GetAxisRaw("Vertical") == 0f || Input.GetAxisRaw("Horizontal") == 0f)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("isWalking", 0f);
        }
    }

}
