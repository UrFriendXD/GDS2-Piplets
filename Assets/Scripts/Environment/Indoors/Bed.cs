using Player;
using UnityEngine;
using UnityEngine.Events;

namespace Environment.Indoors
{
    public class Bed : InteractableObject
    {
        public UnityEvent dayPass;
        public Canvas fade;
        //private PlayerScript playerScript;
        
        // Calls day pass event regardless of interaction key
        public override void InteractWithItem(Item item, PlayerScript playerScript)
        {
            dayPass.Invoke();
            fade.GetComponent<Fade>().FadeEffect();
        }
        
        public override void InteractBare(PlayerScript playerScript)
        {
            dayPass.Invoke();
            fade.GetComponent<Fade>().FadeEffect();
        }
    }
}
