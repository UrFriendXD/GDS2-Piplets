using System;
using System.Collections;
using System.Collections.Generic;
using Farming;
using UnityEngine;
using Random = UnityEngine.Random;


[RequireComponent(typeof(SpriteRenderer))]
public class PlantFunctions : MonoBehaviour
{
    // Sprites variables
    //[SerializeField] private Sprite[] plantSprites;
    private SpriteRenderer _spriteRenderer;

    // Remove serialise when no need to debug
    [SerializeField] private PlantStages currentPlantStage; 
    
    // Values to relating to farming
    [SerializeField] private int daysSincePlanted = 0;
    /*private int _daysToStage1;
    private int _daysToHarvest;
    private float _amountToGive;
    private Item _rawGoodToGive;*/
    
    private bool _bIsWatered;
    //private bool _bIsHarvestable;

    private PlantType _thisPlantType;
    private PlantSeed _plantSeed;

    public bool isTesting;

    // Remove serializable later
    [SerializeField] private Player _player;
    
    // Player modifiers to be implemented later
    // private int playerModifier

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual void Plant(PlantSeed plantSeed)
    {
        this._plantSeed = plantSeed;
        //Initialising values from Plants scriptable objects
        //plantSprites = this.plantSeed.plantSprites;

        /*_daysToStage1 = this.plantSeed.daysToStage1;
        _daysToHarvest = this.plantSeed.daysToHarvest;
        _amountToGive = this.plantSeed.amountToGive;
        _rawGoodToGive = plantSeed.rawGoodToGive;*/
        
        _thisPlantType = this._plantSeed.plantType;
        
        // If this is a new plant set stage to seed and seedling sprite
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
        if (isTesting)
        {
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
                Harvest(_player);
            }
        }
    }

    // Basic interacting with plant
    // Harvests if harvestable, destroys if dead
    public void OnInteract(Player player)
    {
        switch (currentPlantStage)
        {
            case PlantStages.Harvestable:
                Harvest(player);
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
    public void Grow()
    {
        // If plant is harvestable ignore growth 
        if (currentPlantStage == PlantStages.Harvestable) return;
        
        //If watered grow a day
        if (_bIsWatered)
        {
            _bIsWatered = false;
            daysSincePlanted++;

            // Depending on day since planted, grow a stage
            switch (daysSincePlanted)
            {
                // var _ is nothing
                case var _ when daysSincePlanted == _plantSeed.daysToStage1:
                    currentPlantStage = PlantStages.Growing;
                    UpdateSprite(1);
                    break;
                case var _ when daysSincePlanted == _plantSeed.daysToHarvest:
                    currentPlantStage = PlantStages.Harvestable;
                    UpdateSprite(_plantSeed.plantSprites.Length-1);
                    break;
                default:
                    Debug.Log("Grew over harvest");
                    break;
            }
        }
        Debug.Log($"Growth {daysSincePlanted}, {currentPlantStage}");

    }

    public void Harvest(Player player)
    {
        if (currentPlantStage == PlantStages.Harvestable)
        {
            // give player resource based on chance
            // higher amt is rarer
            /*var random = Random.Range(0,101);
            switch (random)
            {
                
                case var _ when random >= 80:
                    _amountToGive = giveResourceMax;
                    break;
                default:
                    Debug.Log("Random is out of bounds");
                    break;
            }*/
            
            //Inventory.Gain(amountToGive)
            //Give raw good to player
            player.inventory.AddItem(_plantSeed.rawGoodToGive);

            // Give raw good based on chance * modifier (later on)
            var randomSeed = Random.Range(0, 101);
            if (randomSeed > 50)
            {
                player.inventory.AddItem(_plantSeed);
            }
            Debug.Log($"Gave {_plantSeed.amountToGive}");
            DestroyPlant();

            // Show particles based on amount or just particles
            DestroyPlant();
        }
    }

    public void OnSeasonEnd()
    {
        currentPlantStage = PlantStages.Wilted;
        UpdateSprite(_plantSeed.plantSprites.Length);
    }

    // Updates sprite base on parameter
    private void UpdateSprite(int value) => _spriteRenderer.sprite = _plantSeed.plantSprites[value];

    // Destroys plant and resets it's values
    public void DestroyPlant()
    {
        _spriteRenderer.sprite = null;
        _plantSeed = null;
        _thisPlantType = PlantType.None;
        currentPlantStage = PlantStages.None;
    }

    public bool IsPlanted() => _thisPlantType != PlantType.None;
}
