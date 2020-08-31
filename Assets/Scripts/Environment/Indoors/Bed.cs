using UnityEngine;
using UnityEngine.Events;

namespace Environment.Indoors
{
    public class Bed : InteractableObject
    {
        public UnityEvent dayPass;
        private Player player;
        
        // Calls day pass event regardless of interaction key
        public override void InteractWithItem(Item item, Player player)
        {
            dayPass.Invoke();
        }
        
        public override void InteractBare(Player player)
        {
            base.InteractBare(player);
            dayPass.Invoke();
        }
    }
}
