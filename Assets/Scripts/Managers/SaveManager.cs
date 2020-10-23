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
        foreach (var player in _playersManager.GetAllPlayers())
        {
            ItemSaveManager.SaveInventory(player);
        }
    }

    public void LoadGame()
    {
        foreach (var player in _playersManager.GetAllPlayers())
        {
            ItemSaveManager.LoadInventory(player);
        }
    }

    private void ClearSave()
    {
        
    }
}
