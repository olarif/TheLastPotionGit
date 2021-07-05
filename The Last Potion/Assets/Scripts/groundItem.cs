using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class groundItem : MonoBehaviour, ISerializationCallbackReceiver
{
    public ItemObject itemOnGround;

    public void OnAfterDeserialize()
    {
    }

    public void OnBeforeSerialize()
    {
//#if UNITY_EDITOR
//        GetComponentsInChildren<SpriteRenderer>().sprite = itemOnGround.uiDisplay;
//        EditorUtility.SetDirty(GetComponentsInChildren<SpriteRenderer>());
//#endif
    }
}
