using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipletSaveManager : MonoBehaviour
{
    public PipletsDatabase PipletsDatabase;
    private const string SavedPipletsFileName = "SavedPiplets";

    private void Awake()
    {
        ServiceLocator.Current.Get<SaveManager>().PipletSaveManager = this;
    }

    public void SaveGame()
    {
        SavePiplets(PipletsDatabase._pipletStats, SavedPipletsFileName);
    }

    public void LoadGame()
    {
        PipletListSaveData pipletListSaveData = PipletSaveIO.LoadPiplets(SavedPipletsFileName);
        if (pipletListSaveData == null)
        {
            return;
        }

        for (int i = 0; i < pipletListSaveData.savedPiplets.Length; i++)
        {
            var saveData = pipletListSaveData.savedPiplets[i];
            foreach (var pipletStat in PipletsDatabase._pipletStats)
            {
                if (saveData.pipletId == pipletStat.ID)
                {
                    pipletStat.level = saveData.level;
                    pipletStat.steps = saveData.steps;
                    pipletStat.isUnlocked = saveData.isUnlocked;
                    break;
                }
            }    
        }
    }

    private void SavePiplets(IList<PipletStats> pipletStats, string fileName)
    {
        var saveData = new PipletListSaveData(pipletStats.Count);

        for (int i = 0; i < saveData.savedPiplets.Length; i++)
        {
            saveData.savedPiplets[i] = new PipletSaveData(pipletStats[i].ID, pipletStats[i].level, pipletStats[i].steps, pipletStats[i].isUnlocked);
        }
        
        PipletSaveIO.SavePiplets(saveData, fileName);
    }

    public void NewGame()
    {
        for (int i = 0; i < PipletsDatabase._pipletStats.Length; i++)
        {
            PipletStats pipletStats = PipletsDatabase._pipletStats[i];
            if (i == 0)
            {
                pipletStats.isUnlocked = true;
            }
            else
            {
                pipletStats.isUnlocked = false;
            }

            pipletStats.level = 1;
            pipletStats.steps = 0;
        }
    }
}
