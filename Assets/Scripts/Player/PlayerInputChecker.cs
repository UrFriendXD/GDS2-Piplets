using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputChecker : MonoBehaviour
{
    public delegate void OnActionPressed();
    public event OnActionPressed Pressed;
    public delegate void OnActionBare();
    public event OnActionBare BarePressed;

    private playerMovement playerMovement;
    private Player player;

    private void Start()
    {
        playerMovement = GetComponent<playerMovement>();
        player = GetComponent<Player>();
    }

    // Calls Pressed event when Action is pressed
    private void OnAction()
    {
        if (!player.itemHeld) return;
        if (Pressed == null) return;
        Pressed();
        playerMovement.Interact();
        Debug.Log("Action");
    }
    
    // Calls BarePressed event when Interact bare is pressed
    private void OnInteractBare()
    {
        BarePressed?.Invoke();
    }
}
