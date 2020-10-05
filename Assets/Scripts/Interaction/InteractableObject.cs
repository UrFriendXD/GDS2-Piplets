using Interaction;
using Player;
using UnityEngine;

[RequireComponent(typeof(PlayerDetector))]
public class InteractableObject : MonoBehaviour
{
    // Interacting with bare hands
    public virtual void InteractBare(PlayerScript playerScript)
    {
        
    }

    // Interacting with item in hand/use
    public virtual void InteractWithItem(Item item, PlayerScript playerScript)
    {
        
    }
}
