using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MarketManager : IGameService
{
    [SerializeField] private List<TradableItem> tradableItems = new List<TradableItem>();
    private Dictionary<TradableItem, int> _itemsSold = new Dictionary<TradableItem, int>();

    public bool newGame;
    
    // Sets price to base if its 0. Adds items to the dictionary
    private void OnValidate()
    {
        foreach (var tradableItem in tradableItems)
        {
            if ( tradableItem.currentSellingPrice == 0)
            {
                tradableItem.currentSellingPrice = tradableItem.baseSellingPrice;
            }
            
            _itemsSold.Add(tradableItem, 0);
        }
    }

    // On start, if it's a new game reset prices
    private void Start()
    {
        if (newGame)
        {
            ResetMarketPrices();
        }
    }

    // Called to add how many items are sold
    public void ItemSold(TradableItem tradableItem, int amount)
    {
        _itemsSold[tradableItem] += amount;
    }

    // Resets the item prices. Can be called during end of season or something?
    private void ResetMarketPrices()
    {
        foreach (var tradableItem in tradableItems)
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
                case var _ when _itemsSold[key] < 3:
                    priceModifier = Random.Range(1,1.7f);
                    break;
                // Down or up if sold a few
                case var _ when _itemsSold[key] < 10:
                    priceModifier = Random.Range(0.85f,  1.5f);
                    break;
                // Likely to go down if sold a lot
                case var _ when _itemsSold[key] < 15:
                    priceModifier = Random.Range(0.7f, 1.1f);
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