using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PreparingDisplay : MonoBehaviour
{
    public AttributesManager attriMan;
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
        for (int i = 0; i < attriMan.attributesArray.Length; i++)
        {
            if (attriMan.attributesArray[i].value.ModifiedValue > 0)
            {
                attriMan.attributesArray[i].attributeDisplay.GetComponentInChildren<TextMeshProUGUI>().text
                    = attriMan.attributesArray[i].value.ModifiedValue.ToString("+0");
            }
            else
            {
                attriMan.attributesArray[i].attributeDisplay.GetComponentInChildren<TextMeshProUGUI>().text
                    = attriMan.attributesArray[i].value.ModifiedValue.ToString("n0");
            }
        }
    }
    public void CreateAttributeSlot()
    {
        //slotsOnInterface = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < attriMan.attributesArray.Length; i++)
        {
            var obj = attributeSlot[i];

            attriMan.attributesArray[i].attributeDisplay = obj;
            //brewingManager.GetValueOfAttribute(brewingManager.attributesArray[i].type);
            AttributesOnInterface.Add(obj, attriMan.attributesArray[i]);
        }
    }
}
