using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Level 1");

    }

    public void LoadGame()
    {
        //scenemanager.loadscene...?
        
    }

    public void ExitGame()
    {
        //debug to check without building. Closes the game
        Debug.Log("game closed.");
        Application.Quit();
    }
}
