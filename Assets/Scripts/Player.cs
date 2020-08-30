using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Player : MonoBehaviour
{
    //[SerializeField] private UI_Inventory _uiInventory;
    [SerializeField] private ItemSaveManager itemSaveManager;
    public Item itemHeld;
    private playerMovement PlayerMovement;
    public delegate void OnActionPressed();
    public event OnActionPressed Pressed;
    public delegate void OnActionBare();
    public event OnActionBare BarePressed;
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
                Pressed();
                break;
            case "Axe":
                PlayerMovement.chop();
                Pressed();
                break;
            case "Aloe Seed":
                PlayerMovement.plant();
                Pressed();
                break;
            case "Tree Seed":
                PlayerMovement.plant();
                Pressed();
                break;
            case "Cotton Seed":
                PlayerMovement.plant();
                Pressed();
                break;
        }
    }

    public void InteractBare()
    {
        BarePressed();
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
