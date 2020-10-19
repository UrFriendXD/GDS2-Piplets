using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : IGameService
{
    public ItemDatabase ItemDatabase;
    private PlayersManager _playersManager;
    
    // Save managers
    public ItemSaveManager ItemSaveManager;
    public MarketPriceSaveManager MarketPriceSaveManager;
    
    public bool IsNewGame;
    public void Setup()
    {
        if (_playersManager == null)
        {
            _playersManager = ServiceLocator.Current.Get<PlayersManager>();
        }
    }
    
    public void NewGame()
    {
        ClearSave();
    }
    
    public void SaveGame()
    {
        // foreach (var player in _playersManager.GetAllPlayers())
        // {
        ItemSaveManager.SaveInventory(_playersManager.GetPlayerFromID(0));
        MarketPriceSaveManager.SavePrices();
        // }
    }

    public void LoadGame()
    {
        // foreach (var player in _playersManager.GetAllPlayers())
        // {
        Debug.Log(_playersManager.GetPlayerFromID(0));
        ItemSaveManager.LoadInventory(_playersManager.GetPlayerFromID(0));
        MarketPriceSaveManager.LoadPrices();
        Debug.Log("Loaded inventory");
        // }
    }

    private void ClearSave()
    {
        //_playersManager.ClearList();
    }
}