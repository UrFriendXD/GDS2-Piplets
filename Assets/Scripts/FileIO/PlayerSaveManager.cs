using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public static class PlayerSaveManager 
{
    private const string SavedPlayerStatsFileName = "PlayerStats";
    
    public static void SaveGame(PlayerStats playerStats)
    {
        SavePlayer(playerStats.money, SavedPlayerStatsFileName);
    }

    public static void LoadGame(PlayerStats playerStats)
    {
        var savedData = PlayerSaveIO.LoadPlayer(SavedPlayerStatsFileName);
        if (savedData == null) return;

        playerStats.money = savedData.money;
    }

    private static void SavePlayer(int money, string fileName)
    {
        var saveData = new PlayerSaveData(money);
        
        PlayerSaveIO.SavePlayer(saveData, fileName);
    }
}
