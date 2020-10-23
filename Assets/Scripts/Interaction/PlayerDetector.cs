using Environment.Indoors;
using Player;
using UnityEngine;

namespace Interaction
{
    public class PlayerDetector : MonoBehaviour
    {
        private PlayerScript playerScript;
        private PlayerMovement playerMovement;
        private PlayerInputChecker playerInputChecker;
        private Item plantSeed;
        private InteractableObject interactableObject;
        private float objectPos;
        protected SpriteRenderer _spriteRenderer;

        // Start is called before the first frame update
        private void Start()
        {
            interactableObject = GetComponent<InteractableObject>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Calls interactableObjects InteractBare()
        protected virtual void InteractBare()
        {
            interactableObject.InteractBare(playerScript);
            if (!CompareTag("Bed"))
            {
                playerScript.playerAnimationController.InteractingAnimation();
            }
        }

        // Calls interactableObjects InteractWithItem()
        protected virtual void InteractWithItem()
        {
            interactableObject.InteractWithItem(playerScript.itemHeld, playerScript);
            //Debug.Log("Planted");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            CheckPlayer(other.gameObject);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            RemovePlayer(other.gameObject);
        }

        private void CheckPlayer(GameObject other)
        {
            if (!other.CompareTag("Player")) return;
            playerScript = other.GetComponent<PlayerScript>();
            
            // Send objects x position for playerMovement
            playerMovement = other.GetComponent<PlayerMovement>();
            playerMovement.TouchObject(transform.position.x);

            // Adds functions to delegate
            playerInputChecker = other.GetComponent<PlayerInputChecker>();
            playerInputChecker.Pressed += InteractWithItem;
            playerInputChecker.BarePressed += InteractBare;
        
            // Changes sprite to be slightly transparent to show it's the current object
            _spriteRenderer.color = new Color(1f, 1f, 1f, .5f);
        }

        private void RemovePlayer(GameObject other)
        {
            if (!other.CompareTag("Player")) return;
            // Reset object x position
            playerMovement.TouchObject(0);
            
            // Removes functions from delegate
            playerInputChecker.Pressed -= InteractWithItem;
            playerInputChecker.BarePressed -= InteractBare;
            
            // Resets variables
            playerScript = null;
            playerMovement = null;
            playerInputChecker = null;
        
            // Changes sprite to be back to normal transparency
            AlphaToggle(other);
        }

        protected virtual void AlphaToggle(GameObject other)
        {
            _spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}