using System.Collections.Generic;
using FileIO;
using UnityEngine;

public class MarketPriceSaveManager : MonoBehaviour
{
    //ItemDatabase itemDatabase;
    
    private const string MarketPricesFileName = "MarketPrices";

    private void Awake()
    {
        var saveManager = ServiceLocator.Current.Get<SaveManager>();
        saveManager.MarketPriceSaveManager = this;
        //itemDatabase = saveManager.ItemDatabase;
    }

    // Function called when saving prices
    public void SavePrices()
    {
        SaveItems(ServiceLocator.Current.Get<MarketManager>()._tradableItemsList.TradableItems, MarketPricesFileName);
    }

    // Loads prices
    public void LoadPrices()
    {
        // Reads save data from file 
        TradableItemListSaveData savedPrices = TradableItemSaveIO.LoadMarketPrices(MarketPricesFileName);
        if (savedPrices == null) return;

        // for each item, go trough each item, check if the ID match up and have the existing price = to the saved price
        for (int i = 0; i < savedPrices.SavedTradableItems.Length; i++)
        {
            TradableItemsList tradableItemsList = ServiceLocator.Current.Get<MarketManager>()._tradableItemsList;
            TradableItemSaveData savedPrice = savedPrices.SavedTradableItems[i];

            foreach (var tradableItem in tradableItemsList.TradableItems)
            {
                if (savedPrice.itemID == tradableItem.ID)
                {
                    tradableItem.currentSellingPrice = savedPrice.currentSellingPrice;
                    break;
                }
            }
        }
    }

    // Saves items in tradable items
    private void SaveItems(IList<TradableItem> tradableItems, string fileName)
    {
        // Create a save data array of length of the tradable items length
        var saveData = new TradableItemListSaveData(tradableItems.Count);

        // For each item, check if it does not equal to the base item and create a new data and add to the saveData array
        for (int i = 0; i < saveData.SavedTradableItems.Length; i++)
        {
            TradableItem item = tradableItems[i];
            //Debug.Log(item.currentSellingPrice);

            if (item.currentSellingPrice != item.baseSellingPrice) {
                saveData.SavedTradableItems[i] = new TradableItemSaveData(item.ID, item.currentSellingPrice);
                //Debug.Log(saveData.SavedTradableItems[i].currentSellingPrice);
            } 
        }

        // Save the prices to persistent data
        TradableItemSaveIO.SaveMarketPrices(saveData, fileName);
    }
}