using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private Transform itemSlotContainer;
    [SerializeField] private Transform itemSlotTemplate;
    [SerializeField] private Image itemSlotImage;
    //[SerializeField] private TextMeshProUGUI amountText;

    public void Awake()
    {

    }

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
        float itemSlotCellSize = 100f;

        foreach (Item item in inventory.GetItemList())
        {
            itemSlotImage.sprite = item.GetSprite();
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize - 150f, y * itemSlotCellSize);

            TextMeshProUGUI amountText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();

            if (item.amount > 1)
            {
                amountText.SetText(item.amount.ToString());
            } else
            {
                amountText.SetText("");
            }

            x++;

            if (x > 4)
            {
                x = 0;
                y++;
            }
        }
    }

}
