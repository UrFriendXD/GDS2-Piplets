using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildPlantSaveIO : MonoBehaviour
{
    private static readonly string baseSavePath;

    static WildPlantSaveIO()
    {
        baseSavePath = Application.persistentDataPath;
    }

    public static void SaveWildPlants(WildPlantListSaveData wildPlantListSaveData, string path)
    {
        FileReadWrite.WriteToBinaryFile(baseSavePath + "/" + path + ".dat", wildPlantListSaveData);
    }

    public static WildPlantListSaveData LoadWildPlants(string path)
    {
        string filePath = baseSavePath + "/" + path + ".dat";

        if (System.IO.File.Exists(filePath))
        {
            return FileReadWrite.ReadFromBinaryFile<WildPlantListSaveData>(filePath);
        }
        return null;
    }
}
