using Player;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private PlayerScript playerScript;
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
    protected virtual void InteractBare()
    {
        interactableObject.InteractBare(playerScript);
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
        playerMovement = other.GetComponent<playerMovement>();
        playerMovement.TouchObject(transform.position.x);

        // Adds functions to delegate
        playerInputChecker = other.GetComponent<PlayerInputChecker>();
        playerInputChecker.Pressed += InteractWithItem;
        playerInputChecker.BarePressed += InteractBare;
        this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
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
        if (this.CompareTag("Door") && other.GetComponent<SpriteRenderer>().sortingOrder == 2)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }
}