using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class BedroomPCUIObject : UIInteractableObject
{
    // Terminal window, to be allocated. Could be changed to a service locator
    [SerializeField] private BedroomPCUIWindow bedroomPcuiWindow;

    public override void Start()
    {
        base.Start();
    }

    public override void InteractBare(PlayerInputChecker playerInputChecker, PlayerScript playerScript)
    {
        // When player interacts open terminal and set inventory
        base.InteractBare(playerInputChecker, playerScript);
        bedroomPcuiWindow.OpenUI();
        Debug.Log("UI activated");
    }

    public override void InteractWithItem(PlayerInputChecker playerInputChecker, PlayerScript playerScript)
    {
        // When player interacts open terminal and set inventory
        base.InteractBare(playerInputChecker, playerScript);
        bedroomPcuiWindow.OpenUI();
    }

    public override void CloseUI()
    {
        base.CloseUI();
        bedroomPcuiWindow.CloseUI();
    }
}
