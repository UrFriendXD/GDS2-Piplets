using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event menuButtonSelect;
    [SerializeField] private AK.Wwise.Event menuButtonBack;
    [SerializeField] private AK.Wwise.Bank menuBank;

    [SerializeField] private AK.Wwise.Event stopAll;

    public AK.Wwise.Event playMainMenu;

    private void Start()
    {
        menuBank.Load();
        if (gameObject.activeSelf)
        {
            playMainMenu.Post(gameObject);
        }
    }

    public void NewGame()
    {
        stopAll.Post(gameObject);
        menuBank.Unload();
        ServiceLocator.Current.Get<SaveManager>().IsNewGame = true;
        //ServiceLocator.Current.Get<PlayersManager>().ClearList();
        SceneManager.LoadScene("Level 1");
    }

    public void LoadGame()
    {
        stopAll.Post(gameObject);
        menuBank.Unload();
        ServiceLocator.Current.Get<SaveManager>().IsNewGame = false;
        //ServiceLocator.Current.Get<PlayersManager>().ClearList();
        SceneManager.LoadScene("Level 1");
    }

    public void ReturnToMenu()
    {
        //AkSoundEngine.ClearBanks();
        stopAll.Post(gameObject);
        //AkSoundEngine.ClearBanks();
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        //debug to check without building. Closes the game
        stopAll.Post(gameObject);
        Debug.Log("game closed.");
        Application.Quit();
    }

    public void PlayButtonSound()
    {
        menuButtonSelect.Post(gameObject);
    }
    
    public void PlayBackButtonSound()
    {
        menuButtonBack.Post(gameObject);
    }
}
