using System;
using System.Collections;
using System.Collections.Generic;
using Farming;
using UnityEngine;

public class PlantsManager : IGameService
{
    private readonly List<FarmPlot> _farmPlots = new List<FarmPlot>();
    
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
}
