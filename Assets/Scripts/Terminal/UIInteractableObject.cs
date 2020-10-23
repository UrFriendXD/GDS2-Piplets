using Interaction;
using Player;
using UnityEngine;

[RequireComponent(typeof(UIPlayerDetector))]
public class UIInteractableObject : MonoBehaviour
{
    protected UIPlayerDetector UIPlayerDetector;
    private int _usingPlayerID;

    public virtual void Start()
    {
        UIPlayerDetector = GetComponent<UIPlayerDetector>();
    }

    // Interacting with bare hands
    public virtual void InteractBare(PlayerInputChecker playerInputChecker, PlayerScript playerScript)
    {
        UIPlayerDetector.RemoveInteraction();
        _usingPlayerID = playerScript.PlayerID;
        playerScript.playerMovement.ToggleMovement();
        // Adds closeUI to "esc"
        playerInputChecker.OnCancelButtonPressed += CloseUI;
    }

    // Interacting with item in hand/use
    public virtual void InteractWithItem(PlayerInputChecker playerInputChecker, PlayerScript playerScript)
    {
        UIPlayerDetector.RemoveInteraction();
        _usingPlayerID = playerScript.PlayerID;
        playerScript.playerMovement.ToggleMovement();
        // Adds closeUI to "esc"
        playerInputChecker.OnCancelButtonPressed += CloseUI;
    }

    public virtual void CloseUI()
    {
        // Remove closeUI from "esc"
        ServiceLocator.Current.Get<PlayersManager>().GetPlayerFromID(_usingPlayerID).playerInputChecker.OnCancelButtonPressed -= CloseUI;
        ServiceLocator.Current.Get<PlayersManager>().GetPlayerFromID(_usingPlayerID).playerMovement.ToggleMovement();
        _usingPlayerID = 0;
    }
}
