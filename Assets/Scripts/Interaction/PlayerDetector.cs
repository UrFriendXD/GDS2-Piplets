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

    private void InteractBare()
    {
        interactableObject.InteractBare(player);
    }

    private void InteractWithItem()
    {
        interactableObject.InteractWithItem(player.itemHeld, player);
        //Debug.Log("Planted");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("on");
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();
            
            playerMovement = other.GetComponent<playerMovement>();
            playerMovement.TouchObject(transform.position.x);

            playerInputChecker = other.GetComponent<PlayerInputChecker>();
            playerInputChecker.Pressed += InteractWithItem;
            playerInputChecker.BarePressed += InteractBare;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("off");
        if (other.CompareTag("Player"))
        {
            playerMovement.TouchObject(0);
            playerInputChecker.Pressed -= InteractWithItem;
            playerInputChecker.BarePressed -= InteractBare;
            player = null;
            playerMovement = null;
            playerInputChecker = null;
        }
    }
}