using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateSaveIO : MonoBehaviour
{
    private static readonly string baseSavePath;

    static DateSaveIO()
    {
        baseSavePath = Application.persistentDataPath;
    }

    public static void SaveDate(DateSaveData date, string path)
    {
        FileReadWrite.WriteToBinaryFile(baseSavePath + "/" + path + ".dat", date);
    }

    public static DateSaveData LoadDate(string path)
    {
        string filePath = baseSavePath + "/" + path + ".dat";

        if (System.IO.File.Exists(filePath))
        {
            return FileReadWrite.ReadFromBinaryFile<DateSaveData>(filePath);
        }
        return null;
    }
}
