using System;

[Serializable]
public class DateSaveData
{
    public int day;
    public int year;
    public DateSaveData(int day, int year)
    {
        this.day = day;
        this.year = year;
    }
}
