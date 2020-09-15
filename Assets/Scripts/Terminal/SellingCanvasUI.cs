using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class SellingCanvasUI : MonoBehaviour
{
    private SellingItemButton[] sellingItemButtons;

    private Inventory _inventory;
    private PlayerStats _playerStats;

    
    // Start is called before the first frame update
    public void Initialise()
    {
        sellingItemButtons = GetComponentsInChildren<SellingItemButton>();
    }

    public void OpenSellingMenu(Inventory inventory, PlayerStats playerStatsParam)
    {
        gameObject.SetActive(true);

        // Initialise crafting recipes only once (i.e. inventory is empty)
        if (!_inventory && !_playerStats)
        {
            _inventory = inventory;
            _playerStats = playerStatsParam;
            
            // Set inventory and player stats for each button
            foreach (var sellingItemButton in sellingItemButtons)
            {
                sellingItemButton.PlayerInventory = _inventory;
                sellingItemButton.playerStats = playerStatsParam;
            }
        }
    }

    // Simply closes the processing Menu
    public void CloseSellingMenu()
    {
        gameObject.SetActive(false);
    }

    // Clears inventory in craftingRecipeUis
    public void CloseUI()
    {
        // Clear variables for each button
        foreach (var sellingItemButton in sellingItemButtons)
        {
            sellingItemButton.PlayerInventory = null;
            sellingItemButton.playerStats = null;
        }
        gameObject.SetActive(false);
    }
    
    // Sells all currently selected items. Called by buttons
    public void SellItems()
    {
        foreach (var sellingItemButton in sellingItemButtons)
        {
            sellingItemButton.SellItems();
        }
    }
}
