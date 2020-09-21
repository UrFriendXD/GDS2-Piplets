using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEditor;
using UnityEngine;

public class UIPlayerDetector : MonoBehaviour
{
    private PlayerScript playerScript;
    private PlayerInputChecker playerInputChecker;
    private UIInteractableObject uiInteractableObject;

    private bool _activated;

    private new void Start()
    {
        uiInteractableObject = GetComponent<UIInteractableObject>();
    }

    private void InteractBare()
    {
        uiInteractableObject.InteractBare(playerInputChecker, playerScript);
        playerInputChecker.OnCancelButtonPressed += AddInteraction;
    }

    private void InteractWithItem()
    {
        uiInteractableObject.InteractBare(playerInputChecker, playerScript);
        playerInputChecker.OnCancelButtonPressed += AddInteraction;
    }

    // Removes functions from delegate
    public void RemoveInteraction()
    {
        playerInputChecker.BarePressed -= InteractBare;
        playerInputChecker.Pressed -= InteractWithItem;
    }
    
    // Adds functions to delegate
    public void AddInteraction()
    {
        playerInputChecker.BarePressed += InteractBare;
        playerInputChecker.Pressed += InteractWithItem;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckPlayer(other.gameObject);
        Debug.Log("touch");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        RemovePlayer(other.gameObject);
    }

    private void CheckPlayer(GameObject other)
    {
        if (!other.CompareTag("Player")) return;
        playerScript = other.GetComponent<PlayerScript>();

        // Adds functions to delegate
        playerInputChecker = other.GetComponent<PlayerInputChecker>();
        AddInteraction();
    }

    private void RemovePlayer(GameObject other)
    {
        if (!other.CompareTag("Player")) return;
        
        // Removes functions from delegate
        RemoveInteraction();
        playerInputChecker.OnCancelButtonPressed -= AddInteraction;
            
        // Resets variables
        playerScript = null;
        playerInputChecker = null;
        
        uiInteractableObject.CloseUI();
    }
}