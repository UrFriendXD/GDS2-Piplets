using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void InteractBare(Player player)
    {
        
    }

    //Interacting with item in hand/use
    public virtual void InteractWithItem(Item item, Player player)
    {
        
    }
}
