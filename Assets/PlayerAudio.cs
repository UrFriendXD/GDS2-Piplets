using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AK.Wwise.Event WaterPlantEvent;
    public AK.Wwise.Event WalkEvent;
    public AK.Wwise.Event HarvestEvent;
    public AK.Wwise.Event SeedPlantingEvent;
    public AK.Wwise.Event DiggingEvent;
    public AK.Wwise.Event WoodChoppingEvent;
    // Start is called before the first frame update
    
    public void PlayWaterPlantEvent()
    {
        WaterPlantEvent.Post(gameObject);
    }
}
