using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : IGameService
{
    public bool IsNewGame;
    public ItemSaveManager ItemSaveManager;
    private PlayersManager _playersManager;

    public bool Setup()
    {
        _playersManager = ServiceLocator.Current.Get<PlayersManager>();
        return IsNewGame;
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
        // }
    }

    public void LoadGame()
    {
        // foreach (var player in _playersManager.GetAllPlayers())
        // {
        ItemSaveManager.LoadInventory(_playersManager.GetPlayerFromID(0));
        // }
    }

    private void ClearSave()
    {
        
    }
}