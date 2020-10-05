using Player;
using UnityEngine;
using Event = AK.Wwise.Event;

public class Door : InteractableObject
{
    public GameObject greenhouse;
    public GameObject outsideGreenHouse;
    public GameObject fireFlies;
    public GameObject piplet;
    public GameObject lights;
    public GameObject globalLights;
    public Event doorEvent;

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
            player.GetComponent<SpriteRenderer>().sortingOrder = 2;
            piplet.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        else
        {
            player.GetComponent<SpriteRenderer>().sortingOrder = 3;
            piplet.GetComponent<SpriteRenderer>().sortingOrder = 3;
        }
        
        // Plays audio 
        PlayDoorEvent();
    }

    private void PlayDoorEvent()
    {
        doorEvent.Post(gameObject);
    }
}
