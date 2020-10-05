using Player;
using UnityEngine;

public class UIInteractableObject : MonoBehaviour
{
    protected UIPlayerDetector uiPlayerDetector;
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
