using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmPlot : MonoBehaviour
{
    [SerializeField] private PlantType currentPlantType;

    [SerializeField] private PlantPrefabs plantPrefab;
    private PlantFunctions _currentPlant;

    /*public FarmPlot(Plant currentPlant)
    {
        _currentPlant = currentPlant;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnPlant(currentPlantType);
        }
    }


    public void Interact()
    {
        /*if (watering)
        {
            _currentPlant.OnWatered();
        }*/
        
        _currentPlant.OnInteract();
    }

    // Plants the plant
    public void OnPlant(PlantType plantType)
    {
        // If it's empty plant
        if (currentPlantType == PlantType.None)
        {
            currentPlantType = plantType;
            
            // Based on what plant is being planted, create prefab and get assign _currentPlant to its plantFunctions
            switch (currentPlantType)
            {
                case PlantType.Aloe:
                    var aloePlant = Instantiate(plantPrefab.aloePrefab, gameObject.transform);
                    _currentPlant = aloePlant.GetComponent<PlantFunctions>();
                    break;
                case PlantType.Cotton:
                    var cottonPlant = Instantiate(plantPrefab.cottonPrefab, gameObject.transform);
                    _currentPlant = cottonPlant.GetComponent<PlantFunctions>();
                    break;
                /*case PlantType.Tree:
                    var treePlant = Instantiate(plantPrefab.treePrefab, gameObject.transform);
                    _currentPlant = treePlant.GetComponent<PlantFunctions>();
                    break;*/
                default:
                    throw new ArgumentOutOfRangeException(nameof(plantType), plantType, null);
            }
        }
    }

    public void DayPassed()
    {
        // Add this function to day delegate
        _currentPlant.Grow();
    }

    /*public void OnDestroyCrop()
    {
        Destroy(_currentPlant);
    }*/

    public void OnSeasonEnd()
    {
        _currentPlant.OnSeasonEnd();
    }
}
