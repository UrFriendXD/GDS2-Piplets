using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private Player player;
    private Item plantSeed;
    private FarmPlot farmPlot;
    private float plantPos;

    // Start is called before the first frame update
    void Start()
    {
        plantPos = transform.position.x;
        farmPlot = GetComponent<FarmPlot>();
    }

    public void InteractBare()
    {
        farmPlot.InteractBare(player);
    }

    public void InteractWithItem()
    {
        farmPlot.InteractWithItem(player.itemHeld, player);
        Debug.Log("Planted");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("on");
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();
            other.GetComponent<playerMovement>().plantOn(plantPos);
            player.Pressed += InteractWithItem;
            player.BarePressed += InteractBare;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("off");
        if (other.CompareTag("Player"))
        {
            other.GetComponent<playerMovement>().plantOff(0f);
            player.Pressed -= InteractWithItem;
            player.BarePressed -= InteractBare;
            player = null;
        }
    }
}
