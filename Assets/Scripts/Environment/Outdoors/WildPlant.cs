using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class WildPlant : MonoBehaviour
{

    [SerializeField] private PlantSeed item;

    [SerializeField] private int refreshAmount;
    private int currentAmount;
    private bool _isEmpty;

    private void Start()
    {
        currentAmount = refreshAmount;
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
                    currentAmount--;
                    if (currentAmount == 0)
                    {
                        _isEmpty = true;
                        SeedPicked();
                    }
                    Debug.Log("Gave item");
                }
            }
        }
    }

    private void SeedPicked()
    {
        gameObject.SetActive(false);
    }

    public void RefreshWildPlant()
    {
        currentAmount = refreshAmount;
    }
}
