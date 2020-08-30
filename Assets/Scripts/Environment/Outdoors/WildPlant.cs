using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildPlant : MonoBehaviour
{

    [SerializeField] private PlantSeed item;

    [SerializeField] private int amount;
    private bool _isEmpty;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("on");
        if (other.CompareTag("Player"))
        {
            // Add item to player if not empty and can add item
            if (!_isEmpty)
            {
                Inventory inventory = other.GetComponent<Player>().inventory;
                Item itemCopy = item.GetCopy();
                if (inventory.AddItem(itemCopy))
                {
                    amount--;
                    if (amount == 0)
                    {
                        _isEmpty = true;
                        SeedPicked();
                    }
                    Debug.Log("Gave item");
                }
                else
                {
                    itemCopy.Destroy();
                }
            }
        }
    }

    private void SeedPicked()
    {
        gameObject.SetActive(false);
    }
}
