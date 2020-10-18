using System;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] private TradableItemsList tradableItemsList;
    [SerializeField] private int amountOfPipletNeededToWin;
    public GameObject MusicManager;
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
        SetupMarket();
        SetupPiplets();
    }

    private void OnValidate()
    {
        if (!MusicManager)
        {
            MusicManager = GetComponentInChildren<MusicManager>().gameObject;
        }
    }

    #region Game setup functions

    private void SetupSaveManger()
    {
        _saveManager = ServiceLocator.Current.Get<SaveManager>();
        _isNewGame = _saveManager.Setup();
        if (_isNewGame)
        {
            _saveManager.NewGame();
        }
        else
        {
            _saveManager.LoadGame();
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
}