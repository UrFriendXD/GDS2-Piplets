using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField] private UI_Inventory _uiInventory;
    [SerializeField] private ItemSaveManager itemSaveManager;
    public Item itemHeld;
    public Inventory inventory;

    public void SelectItem(string itemSelectName)
    {
        itemHeld = null;
        Debug.Log(itemSelectName);
        foreach (var item in inventory.ItemSlots)
        {
            if (!item.Item) continue;
            if (itemSelectName != item.Item.itemName) continue;
            itemHeld = item.Item;
            return;
        }
    }
}
