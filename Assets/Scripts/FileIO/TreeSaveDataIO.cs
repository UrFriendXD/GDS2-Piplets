using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSaveDataIO : MonoBehaviour
{
    private static readonly string baseSavePath;

    static TreeSaveDataIO()
    {
        baseSavePath = Application.persistentDataPath;
    }

    public static void SaveItems(TreeListSaveData items, string path)
    {
        FileReadWrite.WriteToBinaryFile(baseSavePath + "/" + path + ".dat", items);
    }

    public static TreeListSaveData LoadItems(string path)
    {
        string filePath = baseSavePath + "/" + path + ".dat";

        if (System.IO.File.Exists(filePath))
        {
            return FileReadWrite.ReadFromBinaryFile<TreeListSaveData>(filePath);
        }
        return null;
    }
}
