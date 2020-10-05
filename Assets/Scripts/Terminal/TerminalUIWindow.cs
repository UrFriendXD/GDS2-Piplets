using System;
using Player;
using TMPro;
using UnityEngine;

public class TerminalUIWindow : MonoBehaviour
{
    // Canvases
    [SerializeField] private Canvas terminalCanvas;
    [SerializeField] private Canvas mainTerminalCanvas;

    // Scripts of respective UI
    private SellingCanvasUI _sellingCanvasUI;
    private ProcessingCanvasUI _processingCanvasUI;
    private PipletCanvasUI _pipletCanvasUI;
    
    // Player variables
    private Inventory _inventory;
    private PlayerStats _playerStats;
    private PlayerInputChecker _playerInputChecker;
    
    // Audio
    public AK.Wwise.Event buttonSelect;

    private bool _inUse;
    
    // Money changes
    //public Action moneyChanged;

    [SerializeField] private TextMeshProUGUI moneyText;

    // Calls when terminal is opened on the first interact of the session
    public void OpenTerminal(Inventory playerInventory, PlayerStats playerStatsParam, PlayerInputChecker inputChecker)
    {
        if (!_inUse)
        {
            _inUse = true;
            
            // Initialising player variables
            _inventory = playerInventory;
            _playerStats = playerStatsParam;
            _playerInputChecker = inputChecker;
            
            // Open initial UI
            terminalCanvas.gameObject.SetActive(true);
            OpenMainTerminalUI();

            // Adds closeUI to "esc"
            _playerInputChecker.OnCancelButtonPressed += CloseUI;
        }
        ChangeMoneyText();
        ServiceLocator.Current.Get<MarketManager>().MoneyChanged += ChangeMoneyText;
    }

    // Called when you want to close terminalUI completely. It removes all data of the player to allow for multiplayer?
    public void CloseUI()
    {
        if (!_inUse) return;
        
        _inUse = false;
            
        // Change to close menu entirely
        terminalCanvas.gameObject.SetActive(false);
        mainTerminalCanvas.gameObject.SetActive(false);
        _processingCanvasUI.CloseUI();
        _sellingCanvasUI.CloseUI();

        // Remove closeUI from "esc"
        _playerInputChecker.OnCancelButtonPressed -= CloseUI;
    }

    // Opens selling menu, called by buttons
    public void OpenSellingMenu()
    {
        _sellingCanvasUI.OpenSellingMenu(_inventory, _playerStats);

        // Only turns off main terminal canvas if off else turn off processing
        if (mainTerminalCanvas.gameObject.activeSelf)
        {
            mainTerminalCanvas.gameObject.SetActive(false);
        }
        else
        {
            _processingCanvasUI.CloseProcessingMenu();
        }
    }
    
    // Opens selling menu, called by buttons
    public void OpenProcessingMenu()
    {
        //sellingCanvas.gameObject.SetActive(false);
        _processingCanvasUI.OpenProcessingMenu(_inventory);
        
        // Only turns off main terminal canvas if off else turn off selling
        if (mainTerminalCanvas.gameObject.activeSelf)
        {
            mainTerminalCanvas.gameObject.SetActive(false);
        }
        else
        {
            _sellingCanvasUI.CloseSellingMenu();
        }
    }

    public void OpenPipletMenu()
    {
        _pipletCanvasUI.OpenBuyingMenu(_playerStats);
        mainTerminalCanvas.gameObject.SetActive(false);
        // Only turns off main terminal canvas if off else turn off selling
        // if (mainTerminalCanvas.gameObject.activeSelf)
        // {
        //     mainTerminalCanvas.gameObject.SetActive(false);
        // }
        // else
        // {
        //     _sellingCanvasUI.CloseSellingMenu();
        // }
        
    }

    public void OpenMainTerminalUI()
    {
        // Open initial UI
        mainTerminalCanvas.gameObject.SetActive(true);
    }

    public void Initialise()
    {
        // Initialise values 
        _processingCanvasUI = GetComponentInChildren<ProcessingCanvasUI>(true);
        _sellingCanvasUI = GetComponentInChildren<SellingCanvasUI>(true);
        _pipletCanvasUI = GetComponentInChildren<PipletCanvasUI>(true);
        _sellingCanvasUI.Initialise();
        _processingCanvasUI.Initialise();
        _pipletCanvasUI.Initialise();
    }

    public void PlayButtonSelect()
    {
        buttonSelect.Post(gameObject);
    }

    public void ChangeMoneyText()
    {
        moneyText.text = "TP: " + _playerStats.money;
    }
}
