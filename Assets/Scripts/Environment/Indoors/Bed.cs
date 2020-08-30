using UnityEngine;
using UnityEngine.Events;

namespace Environment.Indoors
{
    public class Bed : MonoBehaviour
    {
        public UnityEvent dayPass;
        private Player player;
        private void InteractBare()
        {
            // Causes event to happen
            dayPass.Invoke();
            Debug.Log("Day");
        }
    
        private void InteractWithItem()
        {
            // Causes event to happen
            dayPass.Invoke();
            Debug.Log("Day");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Adds interact bare to interact bare button if player enters trigger
            Debug.Log("Touch");
            if (!other.CompareTag("Player")) return;
            player = other.GetComponent<Player>();
            player.BarePressed += InteractBare;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            // Removes and resets interact bare to interact bare button if player leaves trigger
            if (!other.CompareTag("Player")) return;
            player.Pressed -= InteractWithItem;
            player.BarePressed -= InteractBare;
            player = null;
        }
    }
}
