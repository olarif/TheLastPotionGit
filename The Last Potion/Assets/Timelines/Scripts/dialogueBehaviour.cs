using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class dialogueBehaviour : PlayableBehaviour
{
    private PlayableDirector director;
    public Conversation convo;

    private bool inProgress;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if (!inProgress)
        {
            BeginConversation();
        }
    }

    public void Start()
    {

    }

    public void BeginConversation()
    {
        DialogueManager.StartConversation(convo);
        inProgress = false;
    }

}
