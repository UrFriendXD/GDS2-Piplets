using System;

namespace FileIO
{
    [Serializable]
    public class TradableItemSaveData 
    {
        public string itemID;
        public int currentSellingPrice;

        public TradableItemSaveData(string id, int currentSellingPrice)
        {
            itemID = id;
            this.currentSellingPrice = currentSellingPrice;
        }
    }

    [Serializable]
    public class TradableItemListSaveData
    {
        public TradableItemSaveData[] SavedTradableItems;

        public TradableItemListSaveData(int numItems)
        {
            SavedTradableItems = new TradableItemSaveData[numItems];
        }
    }
}