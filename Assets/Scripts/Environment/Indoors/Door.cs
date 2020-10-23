using System;
using Player;
using UnityEngine;
using Event = AK.Wwise.Event;

public class Door : InteractableObject
{
    public GameObject greenhouse;
    public GameObject outsideGreenHouse;
    public GameObject fireFlies;
    public GameObject lights;
    public GameObject globalLights;

    private DoorAudioController _doorAudioController;

    private void Start()
    {
        _doorAudioController = GetComponent<DoorAudioController>();
    }


    public override void InteractBare(PlayerScript player)
    {
        Debug.Log("Door");
        base.InteractBare(player);
        lights.SetActive(!lights.activeSelf);
        if (globalLights.activeSelf)
        {
            globalLights.SetActive(!globalLights.activeSelf);
        }
        fireFlies.SetActive(!fireFlies.activeSelf);
        greenhouse.SetActive(!greenhouse.activeSelf);
        outsideGreenHouse.SetActive(!outsideGreenHouse.activeSelf);
        if (!globalLights.activeSelf && !greenhouse.activeSelf)
        {
            globalLights.SetActive(!globalLights.activeSelf);
        }
        if (greenhouse.activeSelf)
        {
            player.GetComponent<PlayerMovement>().isInside = true;
            _doorAudioController.LoadInside();
        }
        else if(!greenhouse.activeSelf)
        {
            player.GetComponent<PlayerMovement>().isInside = false;
            _doorAudioController.LoadOutside();
        }
    }
    
}
