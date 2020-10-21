using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBankOnTrigger : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Bank bank;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bank.Load();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bank.Unload();
        }
    }
}
