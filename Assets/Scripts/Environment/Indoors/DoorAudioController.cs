using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAudioController : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Bank greenhouseBank;
    [SerializeField] private AK.Wwise.Bank outsideBank;

    [SerializeField] private AK.Wwise.Event doorEvent;
    [SerializeField] private AK.Wwise.Event changeToDirt;
    [SerializeField] private AK.Wwise.Event changeToStone;

    [SerializeField] private AK.Wwise.Event OutsideAtmos;
    
    // Music
    [SerializeField] private AK.Wwise.Event playOutdoorMusic;
    [SerializeField] private AK.Wwise.Event playIndoorMusic;
    public void LoadOutside()
    {
        changeToDirt.Post(gameObject);
        //doorEvent.Post(gameObject);
        outsideBank.Load();
        //doorEvent.Post(gameObject);
        OutsideAtmos.Post(GameManager.instance.MusicManager);
        playIndoorMusic.Stop(GameManager.instance.MusicManager);
        playOutdoorMusic.Post(GameManager.instance.MusicManager);
        greenhouseBank.Unload();
    }

    public void LoadInside()
    {
        changeToStone.Post(gameObject);
        greenhouseBank.Load();
        OutsideAtmos.Stop(GameManager.instance.MusicManager);
        doorEvent.Post(gameObject);
        playIndoorMusic.Post(GameManager.instance.MusicManager);
        playOutdoorMusic.Stop(GameManager.instance.MusicManager);
        outsideBank.Unload();
    }
}