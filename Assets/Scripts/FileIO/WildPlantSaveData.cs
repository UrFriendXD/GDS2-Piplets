using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WildPlantSaveData
{
    public int plantID;
    public int daysSincePlanted;
    public int currentAmount;
    public bool isEmpty;

    public WildPlantSaveData(int plantID, int daysSincePlanted, int currentAmount, bool isEmpty)
    {
        this.plantID = plantID;
        this.daysSincePlanted = daysSincePlanted;
        this.currentAmount = currentAmount;
        this.isEmpty = isEmpty;
    }
}

[Serializable]
public class WildPlantListSaveData
{
    public WildPlantSaveData[] WildPlantSaveDatas;

    public WildPlantListSaveData(int num)
    {
        WildPlantSaveDatas = new WildPlantSaveData[num];
    }
}