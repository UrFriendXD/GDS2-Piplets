using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

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
