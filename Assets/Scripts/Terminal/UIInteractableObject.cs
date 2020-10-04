using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class UIInteractableObject : MonoBehaviour
{
    private UIPlayerDetector uiPlayerDetector;
    // Interacting with bare hands

    public virtual void Start()
    {
        uiPlayerDetector = GetComponent<UIPlayerDetector>();
    }

    public virtual void InteractBare(PlayerInputChecker playerInputChecker, PlayerScript playerScript)
    {
        uiPlayerDetector.RemoveInteraction();
    }

    // Interacting with item in hand/use
    public virtual void InteractWithItem(PlayerInputChecker playerInputChecker, PlayerScript playerScript)
    {
        uiPlayerDetector.RemoveInteraction();
    }

    public virtual void CloseUI()
    {
        
    }
}
