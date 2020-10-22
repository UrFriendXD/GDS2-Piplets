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
    public PipletSaveManager PipletSaveManager;
    private PlantSaveManager _plantSaveManager;
    private DateSaveManager _dateSaveManager;
    
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

        if (_dateSaveManager == null)
        {
            _dateSaveManager = ServiceLocator.Current.Get<DateSaveManager>();
        }
    }
    
    public void NewGame()
    {
        PipletSaveManager.NewGame();
        _playersManager.NewGame();
        GameManager.instance.DayManager.NewGame();
    }
    
    public void SaveGame()
    {
        // foreach (var player in _playersManager.GetAllPlayers())
        // {
        ItemSaveManager.SaveInventory(_playersManager.GetPlayerFromID(0));
        MarketPriceSaveManager.SavePrices();
        _plantSaveManager.SaveGame();
        _dateSaveManager.SaveGame();
        PipletSaveManager.SaveGame();
        PlayerSaveManager.SaveGame(_playersManager.GetPlayerFromID(0).playerStats);
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
        _dateSaveManager.LoadDate();
        PipletSaveManager.LoadGame();
        PlayerSaveManager.LoadGame(_playersManager.GetPlayerFromID(0).playerStats);
        Debug.Log("Loaded Game");
        // }
    }

    private void ClearSave()
    {
        //_playersManager.ClearList();
    }
}