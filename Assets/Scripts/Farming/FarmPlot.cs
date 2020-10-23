using System;
using Player;
using UnityEngine;

namespace Farming
{
    [RequireComponent(typeof(PlantFunctions))]
    public class FarmPlot : InteractableObject
    {
        // Plant variables
        [SerializeField] private PlantSeed currentPlantType;
        private PlantFunctions _currentPlant;
        public int FarmPlotID;

        [SerializeField] private SpriteRenderer pot;

        private void Awake()
        {
            FarmPlotID = ServiceLocator.Current.Get<PlantsManager>().AddFarmPlot(this);
        }

        // Initialise variables
        private void OnEnable()
        {
            _currentPlant = GetComponent<PlantFunctions>();
            if (currentPlantType != null)
            {
                OnPlant(currentPlantType);
            }
        }

        // Interacting with bare hands/no items in hands
        public override void InteractBare(PlayerScript playerScript)
        {
            if (_currentPlant.IsPlanted())
            {
                _currentPlant.OnInteract(playerScript);
            }
        }

        //Interacting with item in hand/use
        public override void InteractWithItem(Item item, PlayerScript playerScript)
        {
            // Watering can waters plants
            if (item.name == "Watering Can")
            {
                _currentPlant.OnWatered();
                if (!playerScript.playerMovement.isInteracting)
                {
                    playerScript.playerAudio.PlayWaterPlantEvent();
                    playerScript.playerAnimationController.WateringAnimation();
                }
            }
        
            //If it's a seed it'll plant if it's empty
            else if (item as PlantSeed)
            {
                if (item.itemName != "Tree Sapling")
                {
                    // If plant is empty and player has room
                    if (!_currentPlant.IsPlanted() && playerScript.inventory.RemoveItem(item))
                    {
                        OnPlant(item as PlantSeed);
                        if (!playerScript.playerMovement.isInteracting)
                        {
                            playerScript.playerAudio.PlaySeedPlantingEvent();
                            playerScript.playerAnimationController.PlantingAnimation();
                        }
                    }
                }
            }
        }

        // Plants the plant
        private void OnPlant(PlantSeed plantSeed)
        {
            _currentPlant.Plant(plantSeed);
            currentPlantType = plantSeed;
            
            ServiceLocator.Current.Get<PlantsManager>().AddToSaveFarmPlots(this);
        }

        public (string, int, int) SavePlant()
        {
            return (currentPlantType.ID, FarmPlotID, _currentPlant.SavePlant());
        }

        public void LoadPlant(PlantSeed plantSeed, int daysSincePlanted)
        {
            _currentPlant.LoadPlant(daysSincePlanted);
            OnPlant(plantSeed);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                // Changes sprite to be slightly transparent to show it's the current object
                pot.color = new Color(1f, 1f, 1f, .5f);
                Debug.Log("trigger");
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                // Changes sprite to be slightly transparent to show it's the current object
                pot.color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }
}
