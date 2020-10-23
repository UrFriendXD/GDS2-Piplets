using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using TMPro;
using UnityEngine;

public class BuyPipletButton : MonoBehaviour
{
    [SerializeField] private Piplet pipletObject;
    [SerializeField] private int pipletCost;

    [HideInInspector] 
    public PlayerStats playerStats;

    [SerializeField] private TextMeshProUGUI text;

    public AK.Wwise.Event passEvent;
    public AK.Wwise.Event failEvent;

    private void OnValidate()
    {
        text.text = "" + pipletCost;
    }

    public void OnEnable()
    {
        gameObject.SetActive(!pipletObject.pipletStats.isUnlocked);
    }

    public void Purchase()
    {
        if (playerStats.money >= pipletCost)
        {
            pipletObject.gameObject.SetActive(true);
            playerStats.money -= pipletCost;
            ServiceLocator.Current.Get<PipletManager>().PipletBoughtEvent.Invoke();
            passEvent.Post(gameObject);
            ServiceLocator.Current.Get<MarketManager>().MoneyChanged?.Invoke();
            gameObject.SetActive(false);
        }
        else
        {
            failEvent.Post(gameObject);
        }
    }
}