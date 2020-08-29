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
    private void Awake()
    {
        //_uiInventory.SetInventory(inventory);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectItem(String itemSelectID)
    {
        itemHeld = null;
        Debug.Log(itemSelectID);
        foreach (var item in inventory.ItemSlots)
        {
            if (!item.Item) continue;
            if (itemSelectID == item.Item.itemName)
            {
                itemHeld = item.Item;
                return;
            }
        }
    }
}
