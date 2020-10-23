using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PipletSaveData
{
    public string pipletId;
    public int level;
    public int steps;
    public bool isUnlocked;

    public PipletSaveData(string pipletId, int level, int steps, bool isUnlocked)
    {
        this.pipletId = pipletId;
        this.level = level;
        this.steps = steps;
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
