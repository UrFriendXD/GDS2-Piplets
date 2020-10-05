using UnityEngine;

namespace Player
{
    public class PlayerAudio : MonoBehaviour
    {
        // The event list of death
        public AK.Wwise.Event waterPlantEvent;
        public AK.Wwise.Event walkEvent;
        public AK.Wwise.Event harvestEvent;
        public AK.Wwise.Event seedPlantingEvent;
        //public AK.Wwise.Event diggingEvent;
        public AK.Wwise.Event ladderClimbEvent;
        public AK.Wwise.Event ladderDescentEvent;
    
        
        public void PlayWaterPlantEvent()
        {
            waterPlantEvent.Post(gameObject);
        }
        
        public void PlayWalkEvent()
        {
            walkEvent.Post(gameObject);
        }
        
        public void PlayHarvestEvent()
        {
            harvestEvent.Post(gameObject);
        }
        
        public void PlaySeedPlantingEvent()
        {
            seedPlantingEvent.Post(gameObject);
        }
        
        // public void PlayDiggingEvent()
        // {
        //     diggingEvent.Post(gameObject);
        // }

        public void PlayLadderClimbEvent()
        {
            ladderClimbEvent.Post(gameObject);
        }
        
        public void PlayLadderDescentEvent()
        {
            ladderDescentEvent.Post(gameObject);
        }
    }
}
