using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public bool plantOn;
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractBare()
    {
        farmPlot.InteractBare(player);
    }

    public void plant()
    {
        farmPlot.InteractWithItem(player.itemHeld, player);
        Debug.Log("Planted");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("on");
        if (other.CompareTag("Player"))
        {
            plantOn = true;
            player = other.GetComponent<Player>();
            other.GetComponent<playerMovement>().plantOn(plantPos);
            player.Pressed += plant;
            player.BarePressed += InteractBare;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("off");
        if (other.CompareTag("Player"))
        {
            plantOn = false;
            other.GetComponent<playerMovement>().plantOff(0f);
            player.Pressed -= plant;
            player.BarePressed -= InteractBare;
            player = null;
        }
    }
}
