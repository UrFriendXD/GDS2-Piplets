using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildPlantManager : IGameService
{
    private List<WildPlant> _wildPlants = new List<WildPlant>();

    public void Setup()
    {
        if (_wildPlants.Count > 0)
        {
            _wildPlants.Clear();
        }
    }
    
    public int AddWildPlant(WildPlant wildPlant)
    {
        if (_wildPlants.Contains(wildPlant)) return 0;
        _wildPlants.Add(wildPlant);
        return _wildPlants.IndexOf(wildPlant);
    }

    public List<WildPlant> SaveGame()
    {
        return _wildPlants;
    }

    public List<WildPlant> LoadGame()
    {
        return _wildPlants;
    }
}
