using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmPlot : MonoBehaviour
{
    [SerializeField] private PlantType currentPlantType;

    private Plant _currentPlant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlant(PlantType plantType)
    {
        currentPlantType = plantType;
        switch (plantType)
        {
            case PlantType.Aloe:
                break;
            case PlantType.Cotton:
                break;
            case PlantType.Tree:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(plantType), plantType, null);
        }
    }
}
