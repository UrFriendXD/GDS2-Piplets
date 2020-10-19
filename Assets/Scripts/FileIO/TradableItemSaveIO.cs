using System.Collections;
using System.Collections.Generic;
using FileIO;
using UnityEngine;

public class TradableItemSaveIO : MonoBehaviour
{
    private static readonly string baseSavePath;

    static TradableItemSaveIO()
    {
        baseSavePath = Application.persistentDataPath;
    }

    public static void SaveMarketPrices(TradableItemListSaveData items, string path)
    {
        FileReadWrite.WriteToBinaryFile(baseSavePath + "/" + path + ".dat", items);
    }

    public static TradableItemListSaveData LoadMarketPrices(string path)
    {
        string filePath = baseSavePath + "/" + path + ".dat";

        if (System.IO.File.Exists(filePath))
        {
            return FileReadWrite.ReadFromBinaryFile<TradableItemListSaveData>(filePath);
        }
        return null;
    }
}
