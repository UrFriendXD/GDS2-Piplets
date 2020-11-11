using System;
using Player;
using Terminal;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SellingItemButton : TerminalAddRemoveButton
{
    // Item that it sells
    [SerializeField] private TradableItem item;
    
    [HideInInspector]
    public PlayerStats playerStats;
    
    private MarketManager _marketManager;
    private Image icon;

    [SerializeField] private TextMeshProUGUI totalCostText;

    private void Awake()
    {
        GetComponentInChildren<PriceChangeChecker>()._item = item;
        _marketManager = ServiceLocator.Current.Get<MarketManager>();
    }

    private void OnValidate()
    {
        // Sets the ui image to be the ui icon
        icon = GetComponent<Image>();
        icon.sprite = item.icon;
    }

    private void Update()
    {
        // Adds amount
        if (_adding && _delay <= 0)
        {
            if (PlayerInventory.ItemCount(item.ID) > _amount)
            {
                UpdateAmount(_amount += 1);
                _delay = delayReset;
                pass.Post(gameObject);
            }
        }

        // Removes amount
        if (_removing && _delay <= 0)
        {
            if (_amount > 0)
            {
                UpdateAmount(_amount -= 1);
                _delay = delayReset;
                fail.Post(gameObject);
            }
        }

        // Timer
        if (_delay > 0)
        {
            _delay -= Time.deltaTime;
        }
    }

    protected override void UpdateAmount(int changeAmount)
    {
        base.UpdateAmount(changeAmount);
        totalCostText.text = "" + item.currentSellingPrice * _amount;
    }

    // Sells items
    public void SellItems()
    {
        if (_amount <= 0) return;
        for (var i = 0; i < _amount; i++)
        {
            PlayerInventory.RemoveItem(item);
        }

        playerStats.money += item.currentSellingPrice * _amount;
        _marketManager.ItemSold(item, _amount);
        UpdateAmount(0);
        _marketManager.MoneyChanged?.Invoke();
    }
}