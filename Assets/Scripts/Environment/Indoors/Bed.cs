using System;
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

        private SaveManager _saveManager;
        //private PlayerScript playerScript;

        private void Awake()
        {
            _saveManager = ServiceLocator.Current.Get<SaveManager>();
        }

        // Calls day pass event regardless of interaction key
        public override void InteractWithItem(Item item, PlayerScript playerScript)
        {
            Sleep();
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
            Sleep();
        }

        private void Sleep()
        {
            dayPass.Invoke();
            StartCoroutine(fadeToNextDay(time));
            GameManager.instance.SaveGame();
        }
    }
}