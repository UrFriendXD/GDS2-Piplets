using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WildPlantsSaveManager
{
    private const string SavedWildPlantsFileName = "WildPlants";

    public static void SaveGame()
    {
        SaveWildPlants(ServiceLocator.Current.Get<WildPlantManager>().SaveGame(), SavedWildPlantsFileName);
    }

    public static void LoadGame()
    {
        var loadData = WildPlantSaveIO.LoadWildPlants(SavedWildPlantsFileName);
        if (loadData == null) return;

        List<WildPlant> wildPlants = ServiceLocator.Current.Get<WildPlantManager>().LoadGame();
        for (int i = 0; i < loadData.WildPlantSaveDatas.Length; i++)
        {
            WildPlantSaveData wildPlantSaveData = loadData.WildPlantSaveDatas[i];
            foreach (var wildPlant in wildPlants)
            {
                if (wildPlant.wildPlantID == wildPlantSaveData.plantID)
                {
                    wildPlant.LoadWildPlant(wildPlantSaveData.daysSincePlanted, wildPlantSaveData.currentAmount, wildPlantSaveData.isEmpty);
                    break;
                }
            }
        }
    }

    private static void SaveWildPlants(IList<WildPlant> wildPlants, string fileName)
    {
        // Create a save data array of length of the tradable items length
        var saveData = new WildPlantListSaveData(wildPlants.Count);

        // For each seed in array, add to the save list
        for (int i = 0; i < saveData.WildPlantSaveDatas.Length; i++)
        {
            var (item1, item2, item3, item4) = wildPlants[i].SaveWildPlant();

            saveData.WildPlantSaveDatas[i] = new WildPlantSaveData(item1, item2,item3, item4);
            //Debug.Log(item1 + " " + item2 + " " + item3);
        }
        //Debug.Log(saveData);
        // Save the prices to persistent data
        WildPlantSaveIO.SaveWildPlants(saveData, fileName);
    }
}