using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipletSaveIO
{
    private static readonly string baseSavePath;

    static PipletSaveIO()
    {
        baseSavePath = Application.persistentDataPath;
    }

    public static void SavePiplets(PipletListSaveData piplets, string path)
    {
        FileReadWrite.WriteToBinaryFile(baseSavePath + "/" + path + ".dat", piplets);
    }

    public static PipletListSaveData LoadPiplets(string path)
    {
        string filePath = baseSavePath + "/" + path + ".dat";

        if (System.IO.File.Exists(filePath))
        {
            return FileReadWrite.ReadFromBinaryFile<PipletListSaveData>(filePath);
        }
        return null;
    }
}
