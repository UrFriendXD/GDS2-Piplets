using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TreeSaveData
{
    public string itemID;
    public string objectName;
    public int daysSincePlanted;

    public TreeSaveData(string id, string objectName, int daysSincePlanted)
    {
        itemID = id;
        this.objectName = objectName;
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
