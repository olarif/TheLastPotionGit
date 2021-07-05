using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UserInterface : MonoBehaviour
{
    public InventoryObject inventory;
    public Dictionary<GameObject, InventorySlot> slotsOnInterface = new Dictionary<GameObject, InventorySlot>();
    // Start is called before the first frame update

    void Start()
    {
        for (int i = 0; i < inventory.Container.slotArray.Length; i++)
        {
            inventory.Container.slotArray[i].parent = this;
        }
        CreateSlots();
        AddEvent(gameObject, EventTriggerType.PointerEnter, delegate { OnEnterInterface(gameObject); });
        AddEvent(gameObject, EventTriggerType.PointerExit, delegate { OnExitInterface(gameObject); });
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlots();
    }
    public abstract void CreateSlots();
    public void UpdateSlots()
    {
        foreach (KeyValuePair<GameObject, InventorySlot> _slot in slotsOnInterface)
        {
            if (_slot.Value.item.Id >= 0)
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = _slot.Value.ItemObject_.uiDisplay;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = _slot.Value.amount == 1 ? "" : _slot.Value.amount.ToString("n0");
            }
            else
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }
    protected void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }
    public void OnEnter(GameObject obj)
    {
        MouseData.slotHoveredOver = obj;
        Debug.Log("OnEnter");
    }
    public void OnExit(GameObject obj)
    {
        MouseData.slotHoveredOver = null;
        Debug.Log("OnExit");
    }
    public void OnEnterInterface(GameObject obj)
    {
        MouseData.interfaceHoveredOver = obj.GetComponent<UserInterface>();
        Debug.Log("OnEnterInterface");
    }
    public void OnExitInterface(GameObject obj)
    {
        MouseData.interfaceHoveredOver = null;
        Debug.Log("OnExitInterface");
    }
    public void OnDragStart(GameObject obj)
    {
        MouseData.tempItemBeingDragged = createTempItem(obj);
        Debug.Log("OnDragStart");
    }
    public GameObject createTempItem(GameObject obj)
    {
        GameObject tempItem = null;
        if (slotsOnInterface[obj].item.Id >= 0)
        {
            tempItem = new GameObject();
            var rt = tempItem.AddComponent<RectTransform>();
            rt.sizeDelta = new Vector2(80, 80);
            tempItem.transform.SetParent(transform.parent);
            var img = tempItem.AddComponent<Image>();
                img.sprite = slotsOnInterface[obj].ItemObject_.uiDisplay; //inventory.database.GetItem[slotsOnInterface[obj].item.Id].uiDisplay;
                img.raycastTarget = false;
        }
        return tempItem;
    }
    public void OnDragEnd(GameObject obj)
    {
        Destroy(MouseData.tempItemBeingDragged);
        //if (MouseData.interfaceHoveredOver == null)
        //{
        //    slotsOnInterface[obj].RemoveItem();
        //    return;
        //}
        //if (MouseData.slotHoveredOver)
        //{
            InventorySlot mouseHoverSlotData = MouseData.interfaceHoveredOver.slotsOnInterface[MouseData.slotHoveredOver];
            inventory.SwapItems(slotsOnInterface[obj], mouseHoverSlotData);
        //}
        Debug.Log("OnDragEnd");
    }
    public void OnDrag(GameObject obj)
    {
        if (MouseData.tempItemBeingDragged != null)
            MouseData.tempItemBeingDragged.GetComponent<RectTransform>().position = Input.mousePosition;
        Debug.Log("OnDrag");
    }
}
public static class MouseData
{
    public static UserInterface interfaceHoveredOver;
    public static GameObject tempItemBeingDragged;
    public static GameObject slotHoveredOver;
}

//public static class ExtensionMethods
//{
//    public static void UpdateSlotDisplay(this Dictionary<GameObject, InventorySlot> _slotsOnInterface)
//    {
//        foreach (KeyValuePair<GameObject, InventorySlot> _slot in slotsOnInterface)
//        {
//            if (_slot.Value.item.Id >= 0)
//            {
//                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = _slot.Value.ItemObject_.uiDisplay;
//                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
//                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = _slot.Value.amount == 1 ? "" : _slot.Value.amount.ToString("n0");
//            }
//            else
//            {
//                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
//                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
//                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = "";
//            }
//        }
//    }
//}
