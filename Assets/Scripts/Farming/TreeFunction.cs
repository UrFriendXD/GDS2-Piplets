using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using RoboRyanTron.Unite2017.Events;
using Unity.Mathematics;
using Random = UnityEngine.Random;
using UnityEngine.Rendering.UI;

namespace Farming
{
    //[RequireComponent(typeof(SpriteRenderer))]
    public class TreeFunction : MonoBehaviour
    {
        // Sprites variables
        private SpriteRenderer _spriteRenderer;

        // Enum of current stage of the plant
        private TreeStages _currentPlantStage;

        // Values to relating to farming
        [SerializeField] private int daysSincePlanted = 0;

        // Plant variables
        private PlantType _thisPlantType;
        private PlantSeed _plantSeed;
        [SerializeField] private int doubleAmountThreshold = 95;
        [SerializeField] private int seedGiveBackThreshold = 50;

        // Particle systems
        public GameObject harvestParticle;
        public GameObject plantParticle;
        private GameObject clone;

        //public bool isTesting;

        // Player modifiers to be implemented later
        // private int playerModifier

        //To check for day passing
        [SerializeField] private GameEventListener dayPassEventListener;
        //[SerializeField] private GameEventListener seasonEndEventListener;

        // Start is called before the first frame update
        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Plant(PlantSeed plantSeed)
        {
           
            _plantSeed = plantSeed;
             clone = Instantiate(plantParticle, new Vector3(0, 0, 0), quaternion.identity);
            this.GetComponent<OutsideParticleEffects>().ParticleOn(clone);
            dayPassEventListener.Response.AddListener(Grow);
            _thisPlantType = _plantSeed.plantType;
            if (daysSincePlanted != 0) return;
            _currentPlantStage = TreeStages.Seed;
            UpdateSprite(0);
        }

        private void UpdateSprite(int value) => _spriteRenderer.sprite = _plantSeed.spritesList[value].sprites[Random.Range(0, _plantSeed.spritesList.Length - 1)];

        private void Grow()
        {
            // If plant is harvestable ignore growth 
            if ((_currentPlantStage == TreeStages.BigTree || _currentPlantStage == TreeStages.None) && !_plantSeed) return;

            daysSincePlanted++;

            // Depending on day since planted, grow a stage
            switch (daysSincePlanted)
            {
                // var _ is nothing
                case var _ when daysSincePlanted == _plantSeed.daysToStage1:
                    _currentPlantStage = TreeStages.SmallTree;
                    UpdateSprite(1);
                    break;
                case var _ when daysSincePlanted == _plantSeed.daysToStage2:
                    _currentPlantStage = TreeStages.MediumTree;
                    UpdateSprite(2);
                    break;
                case var _ when daysSincePlanted == _plantSeed.daysToStage3:
                    _currentPlantStage = TreeStages.BigTree;
                    UpdateSprite(3);
                    dayPassEventListener.Response.RemoveListener(Grow);
                    break;
                default:
                    Debug.Log("Grew over harvest");
                    break;
            }
            Debug.Log($"Growth {daysSincePlanted}, {_currentPlantStage}");
        }

        public void Onchop(PlayerScript playerScript)
        {
            switch (_currentPlantStage)
            {
                case TreeStages.SmallTree:
                    Harvest(playerScript);
                    break;
                case TreeStages.MediumTree:
                    Harvest(playerScript);
                    break;
                case TreeStages.BigTree:
                    Harvest(playerScript);
                    break;
                default:
                    Debug.Log("Interacting with plant failed");
                    break;
            }
        }

        private void Harvest(PlayerScript playerScript)
        {
            if (_currentPlantStage == TreeStages.SmallTree || _currentPlantStage == TreeStages.MediumTree || _currentPlantStage == TreeStages.BigTree)
            {
                // depending on what stage the tree is at changes the amount of wood it drops
                if(_currentPlantStage == TreeStages.SmallTree)
                {
                    _plantSeed.amountToGive = 1;
                }
                if (_currentPlantStage == TreeStages.MediumTree)
                {
                    _plantSeed.amountToGive = 3;
                }
                if(_currentPlantStage == TreeStages.BigTree)
                {
                    _plantSeed.amountToGive = 5;
                }
                var amountToGive = _plantSeed.amountToGive;
                var random = Random.Range(0, 101);

                // Threshold based on player stat 
                doubleAmountThreshold -= (int)playerScript.playerStats.harvestingDoublerModifier.Value;
                switch (random)
                {
                    case var _ when random >= doubleAmountThreshold:
                        amountToGive *= 2;
                        break;
                    default:
                        Debug.Log("Random is out of bounds");
                        break;
                }

                //Give raw good to player
                for (var i = 0; i < amountToGive; i++)
                {
                    playerScript.inventory.AddItem(_plantSeed.rawGoodToGive);
                }
                Debug.Log($"Gave {amountToGive} of {_plantSeed.rawGoodToGive}");


                // Particle systems
                clone = Instantiate(harvestParticle, new Vector3(0, 5, 0), quaternion.identity);
                this.GetComponent<OutsideParticleEffects>().ParticleOn(clone);

                // Plays audio for harvest
                playerScript.playerAudio.PlayHarvestEvent();

                // Gives a seed depending on RNG. Base value of 50.
                var randomSeed = Random.Range(0, 101);
                seedGiveBackThreshold -= (int)playerScript.playerStats.harvestingSeedModifier.Value;
                if (randomSeed > seedGiveBackThreshold)
                {
                    playerScript.inventory.AddItem(_plantSeed);
                    Debug.Log($"Gave a {_plantSeed}");
                }
                else
                {
                    Debug.Log("Gave no seed");
                }

                // Show particles based on amount or just particles
                _plantSeed.amountToGive = 0;
                DestroyPlant();
            }
        }

        // Destroys plant and resets it's values
        private void DestroyPlant()
        {
            _spriteRenderer.sprite = null;
            _plantSeed = null;
            _thisPlantType = PlantType.None;
            _currentPlantStage = TreeStages.None;
            daysSincePlanted = 0;
            dayPassEventListener.Response.RemoveListener(Grow);
            Debug.Log("removed");
        }

        public bool IsPlanted() => _thisPlantType != PlantType.None;

    }
}
