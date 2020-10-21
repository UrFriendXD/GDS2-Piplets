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
    private PlantSaveManager _plantSaveManager;
    public bool IsNewGame;
    public void Setup()
    {
        if (_playersManager == null)
        {
            _playersManager = ServiceLocator.Current.Get<PlayersManager>();
        }

        if (_plantSaveManager == null)
        {
            _plantSaveManager = ServiceLocator.Current.Get<PlantSaveManager>();
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
        _plantSaveManager.SaveGame();
        Debug.Log("Saved game");
        // }
    }

    public void LoadGame()
    {
        // foreach (var player in _playersManager.GetAllPlayers())
        // {
        //Debug.Log(_playersManager.GetPlayerFromID(0));
        ItemSaveManager.LoadInventory(_playersManager.GetPlayerFromID(0));
        _plantSaveManager.LoadGame();
        MarketPriceSaveManager.LoadPrices();
        Debug.Log("Loaded Game");
        // }
    }

    private void ClearSave()
    {
        //_playersManager.ClearList();
    }
}