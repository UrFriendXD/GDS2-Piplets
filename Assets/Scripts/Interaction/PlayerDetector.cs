using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private Player player;
    private playerMovement playerMovement;
    private PlayerInputChecker playerInputChecker;
    private Item plantSeed;
    private InteractableObject interactableObject;
    private float objectPos;

    // Start is called before the first frame update
    private void Start()
    {
        interactableObject = GetComponent<InteractableObject>();
    }

    // Calls interactableObjects InteractBare()
    private void InteractBare()
    {
        interactableObject.InteractBare(player);
    }

    // Calls interactableObjects InteractWithItem()
    private void InteractWithItem()
    {
        interactableObject.InteractWithItem(player.itemHeld, player);
        //Debug.Log("Planted");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();
            
            // Send objects x position for playerMovement
            playerMovement = other.GetComponent<playerMovement>();
            playerMovement.TouchObject(transform.position.x);

            // Adds functions to delegate
            playerInputChecker = other.GetComponent<PlayerInputChecker>();
            playerInputChecker.Pressed += InteractWithItem;
            playerInputChecker.BarePressed += InteractBare;
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("off");
        if (other.CompareTag("Player"))
        {
            // Reset object x position
            playerMovement.TouchObject(0);
            
            // Removes functions from delegate
            playerInputChecker.Pressed -= InteractWithItem;
            playerInputChecker.BarePressed -= InteractBare;
            
            // Resets variables
            player = null;
            playerMovement = null;
            playerInputChecker = null;
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }
}