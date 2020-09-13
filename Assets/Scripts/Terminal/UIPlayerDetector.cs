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

    private new void Start()
    {
        uiInteractableObject = GetComponent<UIInteractableObject>();
    }

    private void InteractBare()
    {
        uiInteractableObject.InteractBare(playerInputChecker, playerScript);
    }

    private void InteractWithItem()
    {
        uiInteractableObject.InteractBare(playerInputChecker, playerScript);
    }

    public void RemoveInteraction()
    {
        playerInputChecker.BarePressed -= InteractBare;
        playerInputChecker.Pressed -= InteractWithItem;
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
        playerInputChecker.Pressed += InteractWithItem;
        playerInputChecker.BarePressed += InteractBare;
    }

    private void RemovePlayer(GameObject other)
    {
        if (!other.CompareTag("Player")) return;
        
        // Removes functions from delegate
        playerInputChecker.Pressed -= InteractWithItem;
        playerInputChecker.BarePressed -= InteractBare;
            
        // Resets variables
        playerScript = null;
        playerInputChecker = null;
    }
}
