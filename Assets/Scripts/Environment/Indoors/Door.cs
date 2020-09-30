using Player;
using UnityEngine;
using Event = AK.Wwise.Event;

public class Door : InteractableObject
{
    public GameObject greenhouse;
    public GameObject outsideGreenHouse;
    public GameObject piplet;
    public Event doorEvent;

    public override void InteractBare(PlayerScript player)
    {
        Debug.Log("Door");
        base.InteractBare(player);
        greenhouse.SetActive(!greenhouse.activeSelf);
        outsideGreenHouse.SetActive(!outsideGreenHouse.activeSelf);
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
