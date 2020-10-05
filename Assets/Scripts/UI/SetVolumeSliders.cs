using UnityEngine;

public class SetVolumeSliders : MonoBehaviour
{
    [SerializeField] private float masterVolume;
    [SerializeField] private float musicVolume;
    [SerializeField] private float sfxVolume;

    [SerializeField] private AK.Wwise.Event buttonEvent;
    
    public void SetMasterVolume(float value)
    {
        AkSoundEngine.SetRTPCValue("MasterVolume", value);
        masterVolume = value;
    }
    public void SetSFXVolume(float value)
    {
        AkSoundEngine.SetRTPCValue("SFXVolume", value);
        sfxVolume = value;
    }
    public void SetMusicVolume(float value)
    {
        AkSoundEngine.SetRTPCValue("MusicVolume", value);
        musicVolume = value;
    }

    public void PlayButtonSound()
    {
        buttonEvent.Post(gameObject);
    }
}
