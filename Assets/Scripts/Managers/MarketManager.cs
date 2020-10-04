using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MarketManager : IGameService
{
    private TradableItemsList _tradableItemsList;
    private Dictionary<TradableItem, int> _itemsSold = new Dictionary<TradableItem, int>();
    
    // On start, if it's a new game reset prices
    public void Setup(bool isNewGame, TradableItemsList tradableItemsList)
    {
        _tradableItemsList = tradableItemsList; 
        
        // For each items add to dict and set their current price to base price
        foreach (var tradableItem in _tradableItemsList.TradableItems)
        {
            // Was meant to be for onvalidate so you didn't need to manually set current price as base price but now is redundant
            // if ( tradableItem.currentSellingPrice == 0)
            // {
            //     tradableItem.currentSellingPrice = tradableItem.baseSellingPrice;
            // }
            
            // Initialise the dictionary so all items start with amount of 0
            _itemsSold.Add(tradableItem, 0);
        }
        
        // If it's a new game, reset item prices
        if (isNewGame)
        {
            ResetMarketPrices();
        }
        Debug.Log("Market manager intialised");
    }

    // Called to add how many items are sold
    public void ItemSold(TradableItem tradableItem, int amount)
    {
        _itemsSold[tradableItem] += amount;
        Debug.Log(tradableItem + " " + amount);
    }

    // Resets the item prices. Can be called during end of season or something?
    private void ResetMarketPrices()
    {
        foreach (var tradableItem in _tradableItemsList.TradableItems)
        {
            tradableItem.currentSellingPrice = tradableItem.baseSellingPrice;
            _itemsSold[tradableItem] = 0;
        }
    }

    // Called on the game event listener on when a day is passed
    public void OnDayPassed()
    {
        FluctuatePrices();
        ResetAmount();
    }
    
    // Changes price of items based on amount sold
    private void FluctuatePrices()
    {
        foreach (var key in _itemsSold.Keys.ToList())
        {
            float priceModifier = 0;
            
            // Switch case for values
            switch (_itemsSold[key])
            {
                // Trend upwards
                case var _ when _itemsSold[key] < 4:
                    priceModifier = Random.Range(0.8f, 1.6f);
                    break;
                // Down or up if sold a few
                case var _ when _itemsSold[key] < 10:
                    priceModifier = Random.Range(0.70f,  1.4f);
                    break;
                // Likely to go down if sold a lot
                case var _ when _itemsSold[key] < 15:
                    priceModifier = Random.Range(0.55f, 1.1f);
                    break;
            }
            priceModifier = Mathf.Round(priceModifier * 100f) / 100f;
            key.currentSellingPrice = (int) Mathf.Round(Mathf.Clamp(key.currentSellingPrice * priceModifier,
                key.baseSellingPrice * 0.3f, key.baseSellingPrice * 2.5f));
            Debug.Log(key.currentSellingPrice);
        }
    }
    
    // Reset amount sold for the day
    private void ResetAmount()
    {
        foreach (var key in _itemsSold.Keys.ToList())
        {
            _itemsSold[key] = 0;
        }
    }
}