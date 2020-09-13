using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Terminal : UIInteractableObject
{
    // Canvases
    [SerializeField] private Canvas sellingCanvas;
    [SerializeField] private Canvas processingCanvas;
    
    // Confirm buttons
    [SerializeField] private SellingConfirmButton sellingConfirmButton;
    
    // Arrays
    private SellingItemButton[] sellingItemButtons;
    private ProcessingItemButton[] processingItemButtons;
    
    // Player variables
    private Inventory inventory;
    private PlayerStats playerStats;
    private PlayerInputChecker _playerInputChecker;

    private bool BinUse;

    public override void Start()
    {
        base.Start();
        
        // Puts the buttons in their arrays
        sellingItemButtons = sellingCanvas.GetComponentsInChildren<SellingItemButton>(true);
        processingItemButtons = processingCanvas.GetComponentsInChildren<ProcessingItemButton>(true);
    }

    public override void InteractBare(PlayerInputChecker playerInputChecker, PlayerScript playerScript)
    {
        // When player interacts open terminal and set inventory
        base.InteractBare(playerInputChecker, playerScript);
        inventory = playerScript.inventory;
        playerStats = playerScript.playerStats;
        _playerInputChecker = playerInputChecker;
        OpenTerminal();
        Debug.Log("UI activated");
    }

    public override void InteractWithItem(PlayerInputChecker playerInputChecker, PlayerScript playerScript)
    {
        // When player interacts open terminal and set inventory
        base.InteractBare(playerInputChecker, playerScript);
        inventory = playerScript.inventory;
        playerStats = playerScript.playerStats;
        _playerInputChecker = playerInputChecker;
        OpenTerminal();
    }
    
    private void OpenTerminal()
    {
        if (!BinUse)
        {
            BinUse = true;
            
            // Change to first interface
            OpenSellingMenu();
            
            // Set inventory for each button
            foreach (var sellingItemButton in sellingItemButtons)
            {
                sellingItemButton.PlayerInventory = inventory;
                sellingItemButton.PlayerStats = playerStats;
            }
            
            // Do the same as above for processing
            foreach (var processingItemButton in processingItemButtons)
            {
                //processingItemButton.inventory = inventory;
            }
            
            // Allocates terminal to confirm buttons
            sellingConfirmButton.terminal = this;
            // processing

            _playerInputChecker.OnCancelButtonPressed += CloseTerminal;
        }
    }

    private void CloseTerminal()
    {
        if (BinUse)
        {
            BinUse = false;
            
            // Change to close menu entirely
            sellingCanvas.gameObject.SetActive(false);
            
            // Set inventory for each button
            foreach (var sellingItemButton in sellingItemButtons)
            {
                sellingItemButton.PlayerInventory = null;
                sellingItemButton.PlayerStats = null;
            }
            
            // Do the same as above for processing
            foreach (var processingItemButton in processingItemButtons)
            {
                //processingItemButton.inventory = null;
            }
            
            _playerInputChecker.OnCancelButtonPressed -= CloseTerminal;
        }
    }

    private void OpenSellingMenu()
    {
        sellingCanvas.gameObject.SetActive(true);
        processingCanvas.gameObject.SetActive(false);
    }
    
    private void OpenProcessingMenu()
    {
        sellingCanvas.gameObject.SetActive(false);
        processingCanvas.gameObject.SetActive(true);
    }

    public void SellItems()
    {
        foreach (var sellingItemButton in sellingItemButtons)
        {
            sellingItemButton.SellItems();
        }
    }
}
