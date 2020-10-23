using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class PipletCanvasUI : MonoBehaviour
{
    private BuyPipletButton[] buyPipletButtons;
    private PlayerStats _playerStats;
    // Start is called before the first frame update
    public void Initialise()
    {
        buyPipletButtons = GetComponentsInChildren<BuyPipletButton>();
    }
    
    public void OpenBuyingMenu(PlayerStats playerStatsParam)
    {
        gameObject.SetActive(true);
        // Initialise crafting recipes only once (i.e. inventory is empty)
        if (!_playerStats)
        {
            _playerStats = playerStatsParam;
            
            // Set inventory and player stats for each button
            foreach (var button in buyPipletButtons)
            {
                button.playerStats = playerStatsParam;
                //button.Open();
            }
        }
    }

    public void ClosePipletMenu()
    {
        gameObject.SetActive(false);
    }

    public void CloseUI()
    {
        foreach (var pipletButton in buyPipletButtons)
        {
            pipletButton.playerStats = null;
        }

        _playerStats = null;
        ClosePipletMenu();
    }
}
