using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSeedSaveIO : MonoBehaviour
{
    private static readonly string baseSavePath;

    static PlantSeedSaveIO()
    {
        baseSavePath = Application.persistentDataPath;
    }

    public static void SaveItems(PlantSeedListSaveData items, string path)
    {
        FileReadWrite.WriteToBinaryFile(baseSavePath + "/" + path + ".dat", items);
    }

    public static PlantSeedListSaveData LoadItems(string path)
    {
        string filePath = baseSavePath + "/" + path + ".dat";

        if (System.IO.File.Exists(filePath))
        {
            return FileReadWrite.ReadFromBinaryFile<PlantSeedListSaveData>(filePath);
        }
        return null;
    }
}
