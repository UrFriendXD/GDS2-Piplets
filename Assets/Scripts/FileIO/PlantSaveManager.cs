using System;
using System.Collections;
using System.Collections.Generic;
using Farming;
using UnityEngine;

public class PlantSaveManager : IGameService
{
    private const string SavedPlantsFileName = "FarmPlots";

    public void SaveGame()
    {
        SavePlants(ServiceLocator.Current.Get<PlantsManager>().SavePlants(), SavedPlantsFileName);
    }

    public void LoadGame()
    {
        PlantSeedListSaveData savedPlants = PlantSeedSaveIO.LoadItems(SavedPlantsFileName);
        if (savedPlants == null) return;

        List<FarmPlot> farmPlots = ServiceLocator.Current.Get<PlantsManager>().LoadPlants();
        ItemDatabase itemDatabase = ServiceLocator.Current.Get<SaveManager>().ItemDatabase;
        Debug.Log(farmPlots.Count);
        for (int i = 0; i < savedPlants.savedPlantSeeds.Length; i++)
        {
            PlantSeedSaveData savedFarmPlot = savedPlants.savedPlantSeeds[i];
            foreach (var farmPlot in farmPlots)
            {
                if (farmPlot.FarmPlotID == savedFarmPlot.farmPlotID)
                {
                    farmPlot.LoadPlant(itemDatabase.GetItemCopy(savedFarmPlot.itemID) as PlantSeed, savedFarmPlot.daysSincePlanted);
                    Debug.Log(farmPlot.FarmPlotID +" " + savedFarmPlot + " " + savedFarmPlot.itemID);
                    break;
                }
            }
        }
    }

    private void SavePlants(IList<FarmPlot> savedFarmPlots, string fileName)
    {
        // Create a save data array of length of the tradable items length
        var saveData = new PlantSeedListSaveData(savedFarmPlots.Count);

        // For each seed in array, add to the save list
        for (int i = 0; i < saveData.savedPlantSeeds.Length; i++)
        {
            var (item1, item2, item3) = savedFarmPlots[i].SavePlant();

            saveData.savedPlantSeeds[i] = new PlantSeedSaveData(item1, item2,item3);
            //Debug.Log(item1 + " " + item2 + " " + item3);
        }
        //Debug.Log(saveData);
        // Save the prices to persistent data
        PlantSeedSaveIO.SaveItems(saveData, fileName);
    }
}