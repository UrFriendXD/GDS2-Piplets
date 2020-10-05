using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SellingItemButton : TerminalAddRemoveButton
{
    // Item that it sells
    [SerializeField] private TradableItem item;
    public PlayerStats playerStats;
    private MarketManager _marketManager;
    private Image icon;

    private void Start()
    {
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
            }
        }

        // Removes amount
        if (_removing && _delay <= 0)
        {
            if (_amount > 0)
            {
                UpdateAmount(_amount -= 1);
                _delay = delayReset;
            }
        }

        // Timer
        if (_delay > 0)
        {
            _delay -= Time.deltaTime;
        }
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
    }
}
