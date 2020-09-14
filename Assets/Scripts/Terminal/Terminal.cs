using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Terminal : UIInteractableObject
{
    // Canvases
    [SerializeField] private Canvas terminalCanvas;
    [SerializeField] private Canvas sellingCanvas;
    [SerializeField] private Canvas processingCanvas;
    
    // Confirm buttons
    [SerializeField] private SellingConfirmButton sellingConfirmButton;
    
    // Arrays
    private SellingItemButton[] sellingItemButtons;
    private CraftingRecipeUI[] craftingRecipeUis;
    
    // Player variables
    private Inventory inventory;
    private PlayerStats playerStats;
    private PlayerInputChecker _playerInputChecker;

    private bool BinUse;
    
    public bool selling;

    public override void Start()
    {
        base.Start();
        
        // Puts the buttons in their arrays
        sellingItemButtons = sellingCanvas.GetComponentsInChildren<SellingItemButton>(true);
        craftingRecipeUis = processingCanvas.GetComponentsInChildren<CraftingRecipeUI>(true);
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
            terminalCanvas.gameObject.SetActive(true);
            // Change to first interface
            if (selling)
            {
                OpenSellingMenu();
            }
            else
            {
                OpenProcessingMenu();
            }

            // Set inventory for each button
            foreach (var sellingItemButton in sellingItemButtons)
            {
                sellingItemButton.PlayerInventory = inventory;
                sellingItemButton.playerStats = playerStats;
            }
            
            // Do the same as above for processing
            foreach (var craftingRecipeUi in craftingRecipeUis)
            {
                craftingRecipeUi.inventory = inventory;
            }
            
            // Allocates terminal to confirm buttons
            sellingConfirmButton.terminal = this;
            // processing

            _playerInputChecker.OnCancelButtonPressed += CloseUI;
        }
    }

    public override void CloseUI()
    {
        if (BinUse)
        {
            BinUse = false;
            
            // Change to close menu entirely
            terminalCanvas.gameObject.SetActive(false);
            
            // Set inventory for each button
            foreach (var sellingItemButton in sellingItemButtons)
            {
                sellingItemButton.PlayerInventory = null;
                sellingItemButton.playerStats = null;
            }
            
            // Do the same as above for processing
            foreach (var processingItemButton in craftingRecipeUis)
            {
                processingItemButton.inventory = null;
            }
            
            _playerInputChecker.OnCancelButtonPressed -= CloseUI;
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

    public void CraftItems()
    {
        foreach (var craftingRecipeUi in craftingRecipeUis)
        {
            craftingRecipeUi.OnCraftButtonClick();
        }
    }
}
