using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;

/*
 * Contains functions relating to days & seasons
 */
public class DayManager : MonoBehaviour
{
    public int days;
    public int years;

    [SerializeField] private GameEvent seasonEndEvent;
    [SerializeField] private SurvivialItemUsed survivalItemUsed;
    
    // Change later with service locator pattern
    [SerializeField] private ItemContainer playerInventory;

    // Called on event DayPassed
    public void DayPassed()
    {
        days++;
        if (WeekCheck())
        {
            ConsumeSurvivalItems();
        }
    }

    // Checks if a week passed. If it's 14 days ends the season
    private bool WeekCheck()
    {
        if (days == 14)
        {
            SeasonEnd();
        }
        return days % 7 == 0;
    }

    private void ConsumeSurvivalItems()
    {
        // If player doesn't enough passout else consume items
        if (!survivalItemUsed.CanCraft(playerInventory))
        {
            PassOut();
        }
        else
        {
            survivalItemUsed.Craft(playerInventory);
        }
        Debug.Log("Consume items " + days);
    }

    // Calls season event event
    private void SeasonEnd()
    {
        seasonEndEvent.Raise();
        Debug.Log("Season ended " + days);
        days = 0;
        years++;
    }

    private void PassOut()
    {
        // just idk end game? pfft dunno
        Debug.Log("Passed out");
    }
}
