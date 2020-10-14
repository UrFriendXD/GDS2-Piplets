using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event playBedroomMusic;
    [SerializeField] private AK.Wwise.Event playGreenhouseMusic;

    private bool _bedroom = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement playerMovement = other.GetComponent<playerMovement>();
            if (playerMovement.ladderspeed == 2.5)
            {
                if (_bedroom)
                {
                    playBedroomMusic.Stop(GameManager.instance.MusicManager);
                    playGreenhouseMusic.Post(GameManager.instance.MusicManager);
                    
                }
            }
            else if (playerMovement.ladderspeed == 5)
            {
                if (!_bedroom)
                {
                    playGreenhouseMusic.Stop(GameManager.instance.MusicManager);
                    playBedroomMusic.Post(GameManager.instance.MusicManager);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement playerMovement = other.GetComponent<playerMovement>();
            if (playerMovement.ladderspeed == 2.5)
            {
                _bedroom = false;
            }
            else if (playerMovement.ladderspeed == 5)
            {
                _bedroom = true;
            }
        }
    }
}
