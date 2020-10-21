using System;
using System.Collections;
using System.Collections.Generic;
using Farming;
using UnityEngine;

public class PlantsManager : IGameService
{
    public List<FarmPlot> _farmPlots = new List<FarmPlot>();
    private List<FarmPlot> _saveFarmPlots = new List<FarmPlot>();
    
    public void Setup()
    {
        if (_farmPlots.Count > 0)
        {
            _farmPlots.Clear();
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
}