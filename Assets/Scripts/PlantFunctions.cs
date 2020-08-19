using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


[RequireComponent(typeof(SpriteRenderer))]
public class PlantFunctions : MonoBehaviour
{
    [SerializeField] private Sprite[] plantSprites;
    private SpriteRenderer _spriteRenderer;

    // remove serialise when no need to debug
    [SerializeField] private PlantStages currentPlantStage; 
    
    // Values to relating to farming
    [SerializeField] private int daysSincePlanted = 0;
    private int daysToStage1;
    private int daysToHarvest;
    //[SerializeField] private int giveResourceMin;
    //[SerializeField] private int giveResourceMax;
    private float amountToGive;
    
    private bool _bIsWatered;
    //private bool _bIsHarvestable;

    private PlantType _thisPlantType;
    public Plants _plants;
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        //Initialising values from Plants scriptable objects
        _spriteRenderer = GetComponent<SpriteRenderer>();
        plantSprites = _plants.plantSprites;

        daysToStage1 = _plants.daysToStage1;
        daysToHarvest = _plants.daysToHarvest;
        amountToGive = _plants.amountToGive;

        _thisPlantType = _plants.plantType;
        
        if (daysSincePlanted == 0)
        {
            currentPlantStage = PlantStages.Seed;
            UpdateSprite(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Test functions
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Grow();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            OnWatered();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Harvest();
        }
    }

    public void OnInteract()
    {
        switch (currentPlantStage)
        {
            case PlantStages.Harvestable:
                Harvest();
                break;
            case PlantStages.Wilted:
                DestroyPlant();
                break;
            default:
                Debug.Log("Interacting with plant failed");
                break; 
        }
    }

    // Sets water to true when watered and if not watered
    public void OnWatered()
    {
        if (!_bIsWatered)
        {
            _bIsWatered = true;
            //Set water graphics/particles
        }
    }

    // Grows the plant by a day
    public virtual void Grow()
    {
        // If plant is harvestable ignore growth 
        if (daysSincePlanted >= (int) PlantStages.Harvestable) return;
        
        //If watered grow a day
        if (_bIsWatered)
        {
            _bIsWatered = false;
            daysSincePlanted++;

            // Depending on day since planted, grow a stage
            switch (daysSincePlanted)
            {
                // var _ is nothing
                case var _ when daysSincePlanted == daysToStage1:
                    currentPlantStage = PlantStages.Growing;
                    UpdateSprite(1);
                    break;
                case var _ when daysSincePlanted == daysToHarvest:
                    currentPlantStage = PlantStages.Harvestable;
                    UpdateSprite(plantSprites.Length-1);
                    break;
                default:
                    Debug.Log("Grew over harvest");
                    break;
            }
        }
        Debug.Log($"Growth {daysSincePlanted}, {currentPlantStage}");

    }

    public virtual void Harvest()
    {
        if (currentPlantStage == PlantStages.Harvestable)
        {
            // give player resource based on chance and between resource max and min
            // higher amt is rarer
            /*var random = Random.Range(0,101);
            switch (random)
            {
                case var _ when random <= 40:
                    amountToGive = giveResourceMin;
                    break;
                case var _ when random <= 80:
                    amountToGive = Random.Range(giveResourceMin, giveResourceMax + 1);
                    break;
                case var _ when random < 100:
                    amountToGive = giveResourceMax;
                    break;
                default:
                    Debug.Log("Random is out of bounds");
                    break;
            }*/
            
            //Inventory.Gain(amountToGive)
            Debug.Log($"Gave {amountToGive}");

            // Show particles based on amount or just particles
            DestroyPlant();
        }
    }

    public void OnSeasonEnd()
    {
        currentPlantStage = PlantStages.Wilted;
        UpdateSprite(plantSprites.Length);
    }

    // Updates sprite base on parameter
    private void UpdateSprite(int value) => _spriteRenderer.sprite = plantSprites[value];

    // Destroys plant
    private void DestroyPlant() => Destroy(this);
}
