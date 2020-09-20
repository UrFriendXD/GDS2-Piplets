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

        // Initialise variables
        private void Start()
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
            }
        
            //If it's a seed it'll plant if it's empty
            else if (item as PlantSeed)
            {
                // If plant is empty and player has room
                if (!_currentPlant.IsPlanted()  && playerScript.inventory.RemoveItem(item))
                {
                    OnPlant(item as PlantSeed);
                }
            }
        }

        // Plants the plant
        private void OnPlant(PlantSeed plantSeed)
        {
            _currentPlant.Plant(plantSeed);
            currentPlantType = plantSeed;
        }
    }
}
