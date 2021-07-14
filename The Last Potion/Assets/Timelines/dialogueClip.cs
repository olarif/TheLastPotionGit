using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System;

[Serializable]
public class dialogueClip : PlayableAsset, ITimelineClipAsset
{

    public dialogueBehaviour template = new dialogueBehaviour();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }

    }

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        return ScriptPlayable<dialogueBehaviour>.Create(graph, template);
    }
}
