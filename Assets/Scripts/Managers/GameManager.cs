using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] private TradableItemsList tradableItemsList;
    [SerializeField] private int amountOfPipletNeededToWin;
    public GameObject MusicManager;
    public DayManager DayManager;
    private bool _isNewGame;
    private SaveManager _saveManager;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SetupSaveManger();
        SetupPlantsManager();
        SetupWildPlantsManager();
    }

    private void SetupWildPlantsManager()
    {
        ServiceLocator.Current.Get<WildPlantManager>().Setup();
    }

    private void SetupPlantsManager()
    {
        ServiceLocator.Current.Get<PlantsManager>().Setup();
    }

    // To call functions that need to be done after scene is loaded. Like a start but persists between loading
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level 1")
        {
            _isNewGame = _saveManager.IsNewGame;
            SetupMarket();
            CheckSave();
            SetupPiplets();
        }
    }

    #region Game setup functions

    private void SetupSaveManger()
    {
        _saveManager = ServiceLocator.Current.Get<SaveManager>();
        _saveManager.Setup();
    }

    private void CheckSave()
    {
        if (_isNewGame)
        {
            _saveManager.NewGame();
            //Debug.Log("New");
        }
        else
        {
            _saveManager.LoadGame();
            //Debug.Log("Loaded");
        }
    }

    private void SetupMarket()
    {
        var marketManager = ServiceLocator.Current.Get<MarketManager>();
        marketManager.Setup(_isNewGame, tradableItemsList);
    }

    private void SetupPiplets()
    {
        ServiceLocator.Current.Get<PipletManager>().Setup(amountOfPipletNeededToWin);
    }

    #endregion

    public void SaveGame()
    {
        _saveManager.SaveGame();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    private void OnValidate()
    {
        if (!MusicManager)
        {
            MusicManager = GetComponentInChildren<MusicManager>().gameObject;
        }

        if (!DayManager)
        {
            DayManager = GetComponentInChildren<DayManager>();
        }
    }
}
