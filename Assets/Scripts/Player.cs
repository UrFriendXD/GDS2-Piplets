using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField] private UI_Inventory _uiInventory;
    [SerializeField] private ItemSaveManager itemSaveManager;
    
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
}
