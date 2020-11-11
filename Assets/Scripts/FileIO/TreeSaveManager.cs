using System.Collections;
using System.Collections.Generic;
using Farming;
using UnityEngine;

public class TreeSaveManager : IGameService
{
    private const string SavedPlantsFileName = "FarmPlots";

    public void SaveGame()
    {
        SaveTrees(ServiceLocator.Current.Get<PlantsManager>().SaveTrees(), SavedPlantsFileName);
    }

    public void LoadGame()
    {
        TreeListSaveData savedPlants = TreeSaveDataIO.LoadItems(SavedPlantsFileName);
        if (savedPlants == null) return;

        List<PlantTree> farmPlots = ServiceLocator.Current.Get<PlantsManager>().LoadTrees();
        ItemDatabase itemDatabase = ServiceLocator.Current.Get<SaveManager>().ItemDatabase;
        Debug.Log(farmPlots.Count);
        for (int i = 0; i < savedPlants.savedPlantSeeds.Length; i++)
        {
            TreeSaveData savedFarmPlot = savedPlants.savedPlantSeeds[i];
            foreach (var plantTree in farmPlots)
            {
                if (plantTree.gameObject.name == savedFarmPlot.objectName)
                {
                    plantTree.LoadTree(itemDatabase.GetItemCopy(savedFarmPlot.itemID) as PlantSeed, savedFarmPlot.daysSincePlanted);
                    Debug.Log(plantTree.name +" " + savedFarmPlot + " " + savedFarmPlot.itemID);
                    break;
                }
            }
        }
    }

    private void SaveTrees(IList<PlantTree> savedFarmPlots, string fileName)
    {
        // Create a save data array of length of the tradable items length
        var saveData = new TreeListSaveData(savedFarmPlots.Count);

        // For each seed in array, add to the save list
        for (int i = 0; i < saveData.savedPlantSeeds.Length; i++)
        {
            var (item1, item2, item3) = savedFarmPlots[i].SaveTree();

            saveData.savedPlantSeeds[i] = new TreeSaveData(item1, item2, item3);
            Debug.Log(item1 + " " + item2 + " " + item3);
        }
        //Debug.Log(saveData);
        // Save the prices to persistent data
        TreeSaveDataIO.SaveItems(saveData, fileName);
    }
}
