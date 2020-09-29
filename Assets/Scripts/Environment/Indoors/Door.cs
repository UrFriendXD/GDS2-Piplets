using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Door : InteractableObject
{
    public GameObject greenhouse;
    public GameObject outsideGreenHouse;
    public GameObject piplet;
    public GameObject lights;
    public GameObject globalLights;
    public AK.Wwise.Event doorEvent;

    public override void InteractBare(PlayerScript player)
    {
        Debug.Log("Door");
        base.InteractBare(player);
        lights.SetActive(!lights.activeSelf);
        if (globalLights.activeSelf)
        {
            globalLights.SetActive(!globalLights.activeSelf);
        }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (CompareTag("Door") && other.GetComponent<SpriteRenderer>().sortingOrder == 2)
            {
                this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }

    private void PlayDoorEvent()
    {
        doorEvent.Post(gameObject);
    }
}
