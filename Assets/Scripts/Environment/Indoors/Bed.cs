using Player;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Environment.Indoors
{
    public class Bed : InteractableObject
    {
        public UnityEvent dayPass;
        public Canvas fade;
        public GameObject player;
        public GameObject insideBed;
        public float time;
        //private PlayerScript playerScript;
        
        // Calls day pass event regardless of interaction key
        public override void InteractWithItem(Item item, PlayerScript playerScript)
        {
            dayPass.Invoke();
            
        }
        
        private IEnumerator fadeToNextDay(float Time)
        {
            player.transform.position = insideBed.transform.position;
            player.gameObject.GetComponent<PlayerMovement>().isUIOn = true;
            yield return new WaitForSeconds(Time); 
            fade.GetComponent<Fade>().FadeEffect();
        }

        public override void InteractBare(PlayerScript playerScript)
        {
            dayPass.Invoke();
            StartCoroutine(fadeToNextDay(time));
        }
    }
}
