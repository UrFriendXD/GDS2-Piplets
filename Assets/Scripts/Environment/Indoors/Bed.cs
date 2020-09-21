using Player;
using UnityEngine;
using UnityEngine.Events;

namespace Environment.Indoors
{
    public class Bed : InteractableObject
    {
        public UnityEvent dayPass;
        private PlayerScript playerScript;
        
        // Calls day pass event regardless of interaction key
        public override void InteractWithItem(Item item, PlayerScript playerScript)
        {
            dayPass.Invoke();
        }
        
        public override void InteractBare(PlayerScript playerScript)
        {
            dayPass.Invoke();
        }
    }
}
