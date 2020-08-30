using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField] private UI_Inventory _uiInventory;
    [SerializeField] private ItemSaveManager itemSaveManager;
    public Item itemHeld;
    private playerMovement PlayerMovement;
    
    public Inventory inventory;
    private void Awake()
    {
        //_uiInventory.SetInventory(inventory);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement = GetComponent<playerMovement>();
    }

    // Update is called once per frame
    public void InteractWithItem()
    {
        if (!itemHeld) return;
        switch (itemHeld.itemName)
        {
            case "Watering Can":
                PlayerMovement.Water();
                break;
            case "Axe":
                PlayerMovement.chop();
                break;
            case "Aloe Seed":
                PlayerMovement.plant(); 
                break;
            case "Tree Seed":
                PlayerMovement.plant();
                break;
            case "Cotton Seed":
                PlayerMovement.plant();
                break;
        }
    }

    public void SelectItem(String itemSelectName)
    {
        itemHeld = null;
        Debug.Log(itemSelectName);
        foreach (var item in inventory.ItemSlots)
        {
            if (!item.Item) continue;
            if (itemSelectName == item.Item.itemName)
            {
                itemHeld = item.Item;
                return;
            }
        }
    }
}
