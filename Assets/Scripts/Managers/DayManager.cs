using Player;
using RoboRyanTron.Unite2017.Events;
using Unity.Mathematics;
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
    
    // Money stat change with service locator later on
    [SerializeField] private PlayerStats playerStats;
    
    // For day passed cause I don't have a clue how to call it else wise
    private MarketManager _marketManager;

    private void Start()
    {
        _marketManager = ServiceLocator.Current.Get<MarketManager>();
    }

    // Called on event DayPassed
    public void DayPassed()
    {
        days++;
        if (WeekCheck())
        {
            ConsumeSurvivalItems();
        }

        _marketManager.OnDayPassed();
    }

    // Checks if a week passed. If it's 14 days ends the season
    private bool WeekCheck()
    {
        if (days == 15)
        {
            SeasonEnd();
        }
        return (days - 1) % 7 == 0;
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
        days = 1;
        years++;
    }

    private void PassOut()
    {
        // Player loses some money
        playerStats.money = (int)math.round((playerStats.money * 0.8));
        //Debug.Log("Player has: " + _playerStats.money);
    }

    public void NewGame()
    {
        days = 1;
        years = 3000;
    }
}
