using System;

[Serializable]
public class PlantSeedSaveData
{
    public string itemID;
    public int farmPlotID;
    public int daysSincePlanted;

    public PlantSeedSaveData(string id, int farmPlotID, int daysSincePlanted)
    {
        itemID = id;
        this.farmPlotID = farmPlotID;
        this.daysSincePlanted = daysSincePlanted;
    }
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