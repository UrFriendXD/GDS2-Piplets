using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Farming
{
    [RequireComponent(typeof(TreeFunction))]
    public class PlantTree : InteractableObject
    {
        [SerializeField] private PlantSeed currentPlantType;
        private TreeFunction _currentTree;
        // Start is called before the first frame update
        void Start()
        {
            _currentTree = GetComponent<TreeFunction>();
            if (currentPlantType != null)
            {
                OnPlant(currentPlantType);
            }
        }

        private void OnPlant(PlantSeed plantSeed)
        {
            _currentTree.Plant(plantSeed);
            currentPlantType = plantSeed;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void InteractWithItem(Item item, PlayerScript playerScript)
        {
            // chopping tree
            if (item.name == "Axe")
            {
                _currentTree.Onchop(playerScript);
                if (!playerScript.playerMovement.isInteracting)
                {
                    //playerScript.PlayerAudio
                    //playerScript.PlayerAnimationController
                }
            }

            //If it's a seed it'll plant if it's empty
            else if (item as PlantSeed)
            {
                currentPlantType = item as PlantSeed;
                if (currentPlantType.itemName == "Tree Sapling")
                {
                    if (!_currentTree.IsPlanted() && playerScript.inventory.RemoveItem(item))
                    {
                        OnPlant(item as PlantSeed);
                        if (!playerScript.playerMovement.isInteracting)
                        {
                            //playerScript.PlayerAudio.PlaySeedPlantingEvent();
                            //playerScript.PlayerAnimationController.PlantingAnimation();
                        }
                    }
                }
            }
        }
    }
}
