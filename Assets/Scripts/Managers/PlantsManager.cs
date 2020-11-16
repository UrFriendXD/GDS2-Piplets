using System;
using System.Collections;
using System.Collections.Generic;
using Farming;
using UnityEngine;
using Object = UnityEngine.Object;

public class PlantsManager : IGameService
{
    public List<FarmPlot> _farmPlots = new List<FarmPlot>();
    private List<FarmPlot> _saveFarmPlots = new List<FarmPlot>();
    public List<PlantTree> PlantTrees = new List<PlantTree>();
    private List<PlantTree> _TreesToSave = new List<PlantTree>();
    
    
    public void Setup()
    {
        if (_farmPlots.Count > 0)
        {
            _farmPlots.Clear();
        }

        if (PlantTrees.Count > 0)
        {
            PlantTrees.Clear();
        }

        var trees = Object.FindObjectsOfType<PlantTree>();
        for (var i = 0; i < trees.Length; i++)
        {
            PlantTrees.Add(trees[i]);
            trees[i].treePlotID = i;
        }
    }
    public int AddFarmPlot(FarmPlot farmPlot)
    {
        if (_farmPlots.Contains(farmPlot)) return 0;
        _farmPlots.Add(farmPlot);
        return _farmPlots.IndexOf(farmPlot);
    }

    public void AddToSaveFarmPlots(FarmPlot farmPlot)
    {
        if (!_saveFarmPlots.Contains(farmPlot))
        {
            _saveFarmPlots.Add(farmPlot);
        }
    }
    
    public void RemoveToSaveFarmPlots(FarmPlot farmPlot)
    {
        if (_saveFarmPlots.Contains(farmPlot))
        {
            _saveFarmPlots.Remove(farmPlot);
        }
    }

    public List<FarmPlot> SavePlants()
    {
        return _saveFarmPlots;
    }

    public List<FarmPlot> LoadPlants()
    {
        return _farmPlots;
    } 
    
    public void AddToSavePlantTrees(PlantTree tree)
    {
        if (!_TreesToSave.Contains(tree))
        {
            _TreesToSave.Add(tree);
        }
    }
    
    public void RemoveToSavePlantTrees(PlantTree tree)
    {
        if (_TreesToSave.Contains(tree))
        {
            _TreesToSave.Remove(tree);
        }
    }
    public List<PlantTree> SaveTrees()
    {
        return _TreesToSave;
    }

    public List<PlantTree> LoadTrees()
    {
        return PlantTrees;
    }
}