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

    public void SavePrices()
    {
        SaveItems(ServiceLocator.Current.Get<MarketManager>()._tradableItemsList.TradableItems, MarketPricesFileName);
    }

    public void LoadPrices()
    {
        TradableItemListSaveData savedPrices = TradableItemSaveIO.LoadMarketPrices(MarketPricesFileName);
        if (savedPrices == null) return;

        for (int i = 0; i < savedPrices.SavedTradableItems.Length; i++)
        {
            //ItemSlot itemSlot = character.inventory.ItemSlots[i];
            TradableItemsList tradableItemsList = ServiceLocator.Current.Get<MarketManager>()._tradableItemsList;
            TradableItemSaveData savedPrice = savedPrices.SavedTradableItems[i];
            Debug.Log(savedPrice.currentSellingPrice);

            foreach (var tradableItem in tradableItemsList.TradableItems)
            {
                if (savedPrice.itemID == tradableItem.ID)
                {
                    tradableItem.currentSellingPrice = savedPrice.currentSellingPrice;
                }
            }
        }
    }

    private void SaveItems(IList<TradableItem> tradableItems, string fileName)
    {
        var saveData = new TradableItemListSaveData(tradableItems.Count);

        for (int i = 0; i < saveData.SavedTradableItems.Length; i++)
        {
            TradableItem item = tradableItems[i];
            //Debug.Log(item.currentSellingPrice);

            if (item.currentSellingPrice != item.baseSellingPrice) {
                saveData.SavedTradableItems[i] = new TradableItemSaveData(item.ID, item.currentSellingPrice);
                //Debug.Log(saveData.SavedTradableItems[i].currentSellingPrice);
            } 
        }

        TradableItemSaveIO.SaveMarketPrices(saveData, fileName);
    }
}