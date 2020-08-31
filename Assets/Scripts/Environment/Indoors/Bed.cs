using UnityEngine;
using UnityEngine.Events;

namespace Environment.Indoors
{
    public class Bed : InteractableObject
    {
        public UnityEvent dayPass;
        private Player player;
        
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
