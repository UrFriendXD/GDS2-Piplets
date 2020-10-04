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
    private SpriteRenderer _spriteRenderer;

    private bool _activated;

    private new void Start()
    {
        uiInteractableObject = GetComponent<UIInteractableObject>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
        //Debug.Log("touch");
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
        
        // Changes sprite to be slightly transparent to show it's the current object
        _spriteRenderer.color = new Color(1f, 1f, 1f, .5f);
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
        
        // Reset Transparency
        _spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        
        // Close UI if player walks out though players shouldn't be able to move if they activate UI
        uiInteractableObject.CloseUI();
    }
}