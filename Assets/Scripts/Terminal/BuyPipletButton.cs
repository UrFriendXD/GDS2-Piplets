using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class BuyPipletButton : MonoBehaviour
{
    [SerializeField] private Piplet pipletObject;
    [SerializeField] private int pipletCost;
    
    [HideInInspector]
    public PlayerStats playerStats;

    public AK.Wwise.Event passEvent;
    public AK.Wwise.Event failEvent;

    public void Purchase()
    {
        if (playerStats.money > pipletCost)
        {
            pipletObject.gameObject.SetActive(true);
            playerStats.money -= pipletCost;
            ServiceLocator.Current.Get<PipletManager>().PipletBoughtEvent.Invoke();
            passEvent.Post(gameObject);
            gameObject.SetActive(false);
        }
        else
        {
            failEvent.Post(gameObject);
        }
    }
}