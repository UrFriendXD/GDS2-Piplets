using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TreeSaveData
{
    public string itemID;
    public int objectID;
    public int daysSincePlanted;

    public TreeSaveData(string id, int objectID, int daysSincePlanted)
    {
        itemID = id;
        this.objectID = objectID;
        this.daysSincePlanted = daysSincePlanted;
    }
}

[Serializable]
public class TreeListSaveData
{
    public TreeSaveData[] savedPlantSeeds;

    public TreeListSaveData(int numItems)
    {
        savedPlantSeeds = new TreeSaveData[numItems];
    }
}
