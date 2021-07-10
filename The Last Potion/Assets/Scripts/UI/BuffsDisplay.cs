using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuffsDisplay : MonoBehaviour
{
    public BuffsManager attriMan;
    public GameObject[] attributeSlot;
    public Dictionary<GameObject, Attribute> AttributesOnInterface = new Dictionary<GameObject, Attribute>();
    private void Start()
    {
        CreateAttributeSlot();
    }
    private void Update()
    {
        OnDisplayUpdate();
    }
    private void OnDisplayUpdate()
    {
        for (int i = 0; i < attriMan.buffsArray.Length; i++)
        {
            if (attriMan.buffsArray[i].value.ModifiedValue > 0)
            {
                attriMan.buffsArray[i].attributeDisplay.GetComponentInChildren<TextMeshProUGUI>().text
                    = attriMan.buffsArray[i].value.ModifiedValue.ToString("+0");
            }
            else
            {
                attriMan.buffsArray[i].attributeDisplay.GetComponentInChildren<TextMeshProUGUI>().text
                    = attriMan.buffsArray[i].value.ModifiedValue.ToString("n0");
            }
        }
    }
    public void CreateAttributeSlot()
    {
        //slotsOnInterface = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < attriMan.buffsArray.Length; i++)
        {
            var obj = attributeSlot[i];

            attriMan.buffsArray[i].attributeDisplay = obj;
            //brewingManager.GetValueOfAttribute(brewingManager.attributesArray[i].type);
            AttributesOnInterface.Add(obj, attriMan.buffsArray[i]);
        }
    }
}
