using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BrewingDisplay : MonoBehaviour
{
    public BrewingManager brewingManager;
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
        for (int i = 0; i < brewingManager.attributesArray.Length; i++)
        {
            if(brewingManager.attributesArray[i].value.ModifiedValue > 0)
            brewingManager.attributesArray[i].attributeDisplay.GetComponentInChildren<TextMeshProUGUI>().text
                = brewingManager.attributesArray[i].value.ModifiedValue.ToString("+0");
            else
                brewingManager.attributesArray[i].attributeDisplay.GetComponentInChildren<TextMeshProUGUI>().text
                    = brewingManager.attributesArray[i].value.ModifiedValue.ToString("n0");

        }
    }
    public void CreateAttributeSlot()
    {
        //slotsOnInterface = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < brewingManager.attributesArray.Length; i++)
        {
            var obj = attributeSlot[i];

            brewingManager.attributesArray[i].attributeDisplay = obj;
            //brewingManager.GetValueOfAttribute(brewingManager.attributesArray[i].type);
            AttributesOnInterface.Add(obj, brewingManager.attributesArray[i]);
        }
    }
}
