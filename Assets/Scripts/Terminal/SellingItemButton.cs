using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SellingItemButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Item that it sells
    [SerializeField] private TradableItem item;
    
    // Player variables set from terminal
    [NonSerialized]
    public Inventory PlayerInventory;
    [NonSerialized]
    public PlayerStats PlayerStats;

    // Values for selling 
    private bool _adding, _removing;
    [SerializeField] private float delayReset;
    private float _delay;
    private int _amount;

    [SerializeField] private Text amountText;

    public void OnPointerDown(PointerEventData eventData)
    {
        // If already add or removing ignore. Forces only one MB active
        if (_adding || _removing) return;
        
        // If LMB add, RMB remove
        switch (eventData.pointerId)
        {
            case -1:
                _adding = true;
                break;
            case -2:
                _removing = true;
                break;
        }
    }

    // Releases current actions
    public void OnPointerUp(PointerEventData eventData)
    {
        _adding = false;
        _removing = false;
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

        PlayerStats.money += item.sellingPrice * _amount;
        UpdateAmount(0);

    }

    private void UpdateAmount(int changeAmount)
    {
        _amount = changeAmount;
        amountText.text = _amount.ToString();
    }
}
