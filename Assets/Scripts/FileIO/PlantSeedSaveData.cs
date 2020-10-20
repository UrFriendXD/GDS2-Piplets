using System;

[Serializable]
public class PlantSeedSaveData
{
    public string itemID;
    public int daysSincePlanted;
    public int farmPlotID;

    public PlantSeedSaveData(string id, int daysSincePlanted, int farmPlotID)
    {
        itemID = id;
        this.daysSincePlanted = daysSincePlanted;
        this.farmPlotID = farmPlotID;
    }
    
    [Serializable]
    public class PlantSeedListSaveData
    {
        public PlantSeedSaveData[] savedPlantSeeds;

        public PlantSeedListSaveData(int numItems)
        {
            savedPlantSeeds = new PlantSeedSaveData[numItems];
        }
    }
}