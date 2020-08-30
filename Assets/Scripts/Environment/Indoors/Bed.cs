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
            dayPass.Invoke();
        }
    
        private void InteractWithItem()
        {
            dayPass.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            player = other.GetComponent<Player>();
            player.BarePressed += InteractBare;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            player.Pressed -= InteractWithItem;
            player.BarePressed -= InteractBare;
            player = null;
        }
    }
}
