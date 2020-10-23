using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basement : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event playBedroomMusic;
    [SerializeField] private AK.Wwise.Event playBasementMusic;

    private bool _bedroom = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement.movementInput < 0 )
            {
                if (_bedroom)
                {
                    //playBedroomMusic.Stop(GameManager.instance.MusicManager);
                    playBasementMusic.Post(GameManager.instance.MusicManager);
                    
                }
            }
            else if (playerMovement.movementInput > 0)
            {
                if (!_bedroom)
                {
                    //playGreenhouseMusic.Stop(GameManager.instance.MusicManager);
                    playBedroomMusic.Post(GameManager.instance.MusicManager);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement.movementInput < 0)
            {
                _bedroom = false;
            }
            else if (playerMovement.movementInput > 0)
            {
                _bedroom = true;
            }
        }
    }
}
