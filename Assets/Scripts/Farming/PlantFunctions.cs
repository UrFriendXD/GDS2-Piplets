using Player;
using RoboRyanTron.Unite2017.Events;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Farming
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlantFunctions : MonoBehaviour
    {
        // Sprites variables
        private SpriteRenderer _spriteRenderer;

        // Enum of current stage of the plant
        private PlantStages _currentPlantStage; 
    
        // Values to relating to farming
        [SerializeField] private int daysSincePlanted = 0;

        // Is the plant watered
        private bool _bIsWatered;

        // Plant variables
        private PlantType _thisPlantType;
        private PlantSeed _plantSeed;
        [SerializeField] private int doubleAmountThreshold = 95;
        [SerializeField] private int seedGiveBackThreshold = 50;

        // Particle systems
        public GameObject waterParticle;
        public GameObject harvestParticle;
        public GameObject plantParticle;
        private GameObject clone;

        //public bool isTesting;

        // Player modifiers to be implemented later
        // private int playerModifier
    
        //To check for day passing
        [SerializeField] private GameEventListener dayPassEventListener;
        [SerializeField] private GameEventListener seasonEndEventListener;

        // Initialising values
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Initialising values on plant
        public void Plant(PlantSeed plantSeed)
        {
            _plantSeed = plantSeed;
            clone = Instantiate(plantParticle, new Vector3(0, 0, 0), quaternion.identity);
            this.GetComponent<OutsideParticleEffects>().ParticleOn(clone);
            dayPassEventListener.Response.AddListener(Grow);
            _thisPlantType = _plantSeed.plantType;
            seasonEndEventListener.Response.AddListener(OnSeasonEnd);
        
            // If this is a new plant set stage to seed and seedling sprite
            if (daysSincePlanted == 0)
            {
                _currentPlantStage = PlantStages.Seed;
                UpdateSprite(0);
            }
            else
            {
                UpdateSpriteOnDay();
            }
        }

        /*// Update is called once per frame
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
                    //Harvest(_player);
                }
            }
        }*/

        // Basic interacting with plant
        // Harvests if harvestable, destroys if dead
        public void OnInteract(PlayerScript playerScript)
        {
            switch (_currentPlantStage)
            {
                case PlantStages.Harvestable:
                    Harvest(playerScript);
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
                clone = Instantiate(waterParticle, new Vector3(0, 0, 0), quaternion.identity);
                this.GetComponent<OutsideParticleEffects>().ParticleOn(clone);
            }
        }

        // Grows the plant by a day
        private void Grow()
        {
            // If plant is harvestable ignore growth 
            if ((_currentPlantStage == PlantStages.Harvestable || _currentPlantStage == PlantStages.None) && !_plantSeed) return;
        
            //If watered grow a day
            if (_bIsWatered)
            {
                _bIsWatered = false;
                daysSincePlanted++;

                // Depending on day since planted, grow a stage
                UpdateSpriteOnDay();
            }
            Debug.Log($"Growth {daysSincePlanted}, {_currentPlantStage}");

        }

        private void UpdateSpriteOnDay()
        {
            switch (daysSincePlanted)
            {
                // var _ is nothing
                case var _ when daysSincePlanted == _plantSeed.daysToStage1:
                    _currentPlantStage = PlantStages.Growing;
                    UpdateSprite(1);
                    break;
                case var _ when daysSincePlanted == _plantSeed.daysToHarvest:
                    _currentPlantStage = PlantStages.Harvestable;
                    UpdateSprite(_plantSeed.spritesList.Length - 2);
                    break;
                default:
                    Debug.Log("Grew over harvest");
                    break;
            }
        }

        private void Harvest(PlayerScript playerScript)
        {
            if (_currentPlantStage == PlantStages.Harvestable)
            {
                // Give player resource based on chance
                // higher amt is rarer
                var amountToGive = _plantSeed.amountToGive;
                var random = Random.Range(0,101);
                
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
                clone = Instantiate(harvestParticle, new Vector3(0, 0, 0), quaternion.identity);
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
                DestroyPlant();
            }
        }

        // Function to set plant to wilted after each season
        public void OnSeasonEnd()
        {
            _currentPlantStage = PlantStages.Wilted;
            UpdateSprite(_plantSeed.spritesList.Length-1);
            dayPassEventListener.Response.RemoveListener(Grow);
            seasonEndEventListener.Response.RemoveListener(OnSeasonEnd);
        }

        // Updates sprite base on parameter/stage. Randomly picks between that stage's sprites
        private void UpdateSprite(int value) => _spriteRenderer.sprite = _plantSeed.spritesList[value].sprites[Random.Range(0, _plantSeed.spritesList[value].sprites.Length - 1)];

        // Destroys plant and resets it's values
        private void DestroyPlant()
        {
            _spriteRenderer.sprite = null;
            _plantSeed = null;
            daysSincePlanted = 0;
            _thisPlantType = PlantType.None;
            _currentPlantStage = PlantStages.None;
            
            dayPassEventListener.Response.RemoveListener(Grow);
            seasonEndEventListener.Response.RemoveListener(OnSeasonEnd);
            ServiceLocator.Current.Get<PlantsManager>().RemoveToSaveFarmPlots(GetComponentInParent<FarmPlot>());
        }

        public bool IsPlanted()
        {
            return _thisPlantType != PlantType.None;
        }

        public int SavePlant()
        {
            return daysSincePlanted;
        }

        public void LoadPlant(int days)
        {
            daysSincePlanted = days;
        }
    }
}