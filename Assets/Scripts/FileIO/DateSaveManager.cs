using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateSaveManager : IGameService
{
    private const string SavedDateFileName = "Date";

    public void SaveGame()
    {
        DayManager dayManager = GameManager.instance.DayManager;
        SaveDate(dayManager.days, dayManager.years, SavedDateFileName);
    }

    public void LoadDate()
    {
        DateSaveData dateSaveData = DateSaveIO.LoadDate(SavedDateFileName);
        if (dateSaveData == null)
        {
            return;
        }

        DayManager dayManager = GameManager.instance.DayManager;
        dayManager.days = dateSaveData.day;
        dayManager.years = dateSaveData.year;
    }

    private void SaveDate(int day, int year, string fileName)
    {
        var saveData = new DateSaveData(day, year);
        
        // Saves data to persistent directory
        DateSaveIO.SaveDate(saveData, fileName);
    }
}
