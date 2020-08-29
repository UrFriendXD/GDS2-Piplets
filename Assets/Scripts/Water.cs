using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float waterpos;
    public bool waterOn;

    private Player player;

    private FarmPlot farmPlot;
    // Start is called before the first frame update
    void Start()
    {
        waterpos = transform.position.x;
        waterOn = false;
        farmPlot = GetComponent<FarmPlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void water()
    {
        farmPlot.InteractWithItem(player.itemHeld, player);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("on");
        if (col.tag == "Player")
        {
            player = col.GetComponent<Player>();
            waterOn = true;
            col.GetComponent<playerMovement>().waterOn(waterpos);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("off");
        if (col.tag == "Player")
        {
            waterOn = false;
            col.GetComponent<playerMovement>().waterOff(0f);
        }
    }
}
