using UnityEngine;

namespace Player
{
    public class PlayerInputChecker : MonoBehaviour
    {
        public delegate void OnActionPressed();
        public event OnActionPressed Pressed;
        public delegate void OnActionBare();
        public event OnActionBare BarePressed;
        public delegate void OnCancelButton();
        public event OnCancelButton OnCancelButtonPressed;

        private playerMovement playerMovement;
        private PlayerScript playerScript;

        private void Start()
        {
            playerMovement = GetComponent<playerMovement>();
            playerScript = GetComponent<PlayerScript>();
        }

        // Calls Pressed event when Action is pressed
        private void OnAction()
        {
            if (!playerScript.itemHeld) return;
            if (Pressed == null) return;
            Pressed();
            playerMovement.Interact(); 
            Debug.Log("Action");
        }
    
        // Calls BarePressed event when Interact bare is pressed
        private void OnInteractBare()
        {
            BarePressed?.Invoke();
        }

        private void OnCancel()
        {
            OnCancelButtonPressed?.Invoke();
            OnCancelButtonPressed = null;
            //Debug.Log("Canceled");
        }
    }
}
