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
        
        [SerializeField] private SpriteRenderer plot;
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
            
            ServiceLocator.Current.Get<PlantsManager>().AddToSavePlantTrees(this);
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
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                // Changes sprite to be slightly transparent to show it's the current object
                plot.color = new Color(1f, 1f, 1f, .5f);
                Debug.Log("trigger");
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                // Changes sprite to be slightly transparent to show it's the current object
                plot.color = new Color(1f, 1f, 1f, 1f);
            }
        }
        
        public (string, string, int) SaveTree()
        {
            return (currentPlantType.ID, gameObject.name, _currentTree.SaveTree());
        }

        public void LoadTree(PlantSeed plantSeed, int daysSincePlanted)
        {
            _currentTree.LoadTree(daysSincePlanted);
            OnPlant(plantSeed);
        }
    }
}
