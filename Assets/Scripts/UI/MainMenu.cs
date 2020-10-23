using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event menuButtonSelect;
    [SerializeField] private AK.Wwise.Bank menuBank;

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
        AkBankManager.DoUnloadBanks();
        menuBank.Unload();
        ServiceLocator.Current.Get<SaveManager>().IsNewGame = true;
        //ServiceLocator.Current.Get<PlayersManager>().ClearList();
        SceneManager.LoadScene("Level 1");
    }

    public void LoadGame()
    {
        AkBankManager.DoUnloadBanks();
        menuBank.Unload();
        ServiceLocator.Current.Get<SaveManager>().IsNewGame = false;
        //ServiceLocator.Current.Get<PlayersManager>().ClearList();
        SceneManager.LoadScene("Level 1");
    }

    public void ReturnToMenu()
    {
        //AkSoundEngine.ClearBanks();
        AkBankManager.DoUnloadBanks();
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        //debug to check without building. Closes the game
        Debug.Log("game closed.");
        Application.Quit();
    }

    public void PlayButtonSound()
    {
        menuButtonSelect.Post(gameObject);
    }
}
