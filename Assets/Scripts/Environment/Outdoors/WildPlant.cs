using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class WildPlant : MonoBehaviour
{

    [SerializeField] private PlantSeed item;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider2D;

    [SerializeField] private int refreshAmount;
    [SerializeField] private int daysToRefresh;
    private int _daysSinceHarvest;
    [SerializeField] private bool canRefresh;
    
    // For "disabling sprite"
    
    
    private int _currentAmount;
    private bool _isEmpty;

    private GameEventListener _gameEventListener;

    private void Start()
    {
        _currentAmount = refreshAmount;
        _gameEventListener = GetComponent<GameEventListener>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Add item to player if not empty and can add item
            if (!_isEmpty)
            {
                Inventory inventory = other.GetComponent<PlayerScript>().inventory;
                Item itemCopy = item.GetCopy();
                if (inventory.AddItem(itemCopy))
                {
                    _currentAmount--;
                    if (_currentAmount == 0)
                    {
                        SeedPicked();
                    }
                    Debug.Log("Gave item");
                }
            }
        }
    }

    // Disables game object
    private void SeedPicked()
    {
        _isEmpty = true;
        _gameEventListener.Response.AddListener(DayPass);
        _spriteRenderer.enabled = false;
        _boxCollider2D.enabled = false;
    }

    // Called to refresh plant so it can be repicked
    private void RefreshWildPlant()
    {
        if (!canRefresh) return;
        _currentAmount = refreshAmount;
        _isEmpty = false;
        _spriteRenderer.enabled = true;
        _boxCollider2D.enabled = true;
    }

    // Called when a day passes
    // Change to a DayManager.day - day when we switch to scene loading
    private void DayPass()
    {
        _daysSinceHarvest++;
        //Debug.Log("Day pass wild plant");
        
        // If days since harvest is > days to refresh, refresh plant and remove this from event listener
        if (_daysSinceHarvest < daysToRefresh) return;
        _daysSinceHarvest = 0;
        RefreshWildPlant();
        _gameEventListener.Response.RemoveListener(DayPass);
    }
}
