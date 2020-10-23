using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveIO : MonoBehaviour
{
    private static readonly string baseSavePath;

    static PlayerSaveIO()
    {
        baseSavePath = Application.persistentDataPath;
    }

    public static void SavePlayer(PlayerSaveData piplets, string path)
    {
        FileReadWrite.WriteToBinaryFile(baseSavePath + "/" + path + ".dat", piplets);
    }

    public static PlayerSaveData LoadPlayer(string path)
    {
        string filePath = baseSavePath + "/" + path + ".dat";

        if (System.IO.File.Exists(filePath))
        {
            return FileReadWrite.ReadFromBinaryFile<PlayerSaveData>(filePath);
        }
        return null;
    }
}
