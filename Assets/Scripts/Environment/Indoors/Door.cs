using Player;
using UnityEngine;
using Event = AK.Wwise.Event;

public class Door : InteractableObject
{
    public GameObject greenhouse;
    public GameObject outsideGreenHouse;
    public GameObject fireFlies;
    public GameObject piplet0;
    public GameObject piplet1;
    public GameObject piplet2;
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
            if (piplet0.activeSelf)
            {
                piplet0.GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
            if (piplet1.activeSelf)
            {
                piplet1.GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
            if (piplet2.activeSelf)
            {
                piplet2.GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
        }
        else
        {
            player.GetComponent<SpriteRenderer>().sortingOrder = 4;
            if (piplet0.activeSelf)
            {
                piplet0.GetComponent<SpriteRenderer>().sortingOrder = 4;
            }
            if (piplet1.activeSelf)
            {
                piplet1.GetComponent<SpriteRenderer>().sortingOrder = 4;
            }
            if (piplet2.activeSelf)
            {
                piplet2.GetComponent<SpriteRenderer>().sortingOrder = 4;
            }
        }
        
        // Plays audio 
        PlayDoorEvent();
    }

    private void PlayDoorEvent()
    {
        doorEvent.Post(gameObject);
    }
}
