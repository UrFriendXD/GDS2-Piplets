using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PipletSaveData
{
    public string pipletId;
    public int level;
    public bool isUnlocked;
    
    public PipletSaveData(string pipletId, int level, bool isUnlocked)
    {
        this.pipletId = pipletId;
        this.level = level;
        this.isUnlocked = isUnlocked;
    }
}

[Serializable]
public class PipletListSaveData
{
    public PipletSaveData[] savedPiplets;

    public PipletListSaveData(int numPiplets)
    {
        savedPiplets = new PipletSaveData[numPiplets];
    }
}
