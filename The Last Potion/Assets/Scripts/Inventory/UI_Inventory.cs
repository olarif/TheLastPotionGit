using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    public GameObject uiInventory;
    [SerializeField] private Transform itemSlotContainer;
    [SerializeField] private Transform itemSlotTemplate;
    [SerializeField] private Image itemSlotImage;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 200f;

        foreach (Item item in inventory.GetItemList())
        {
            itemSlotImage.sprite = item.GetSprite();
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize - 100f, y * itemSlotCellSize);

            TextMeshProUGUI amountText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();

            if (item.amount > 1)
            {
                amountText.SetText(item.amount.ToString());
            } else
            {
                amountText.SetText("");
            }

            x++;

            if (x > 1)
            {
                x = 0;
                y--;
            }
        }
    }

}
