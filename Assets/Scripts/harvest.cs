using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harvest : MonoBehaviour
{
    public bool harvestOn, harvestReady;

    private Player player;

    private FarmPlot farmPlot;
    // Start is called before the first frame update
    void Start()
    {
        farmPlot = GetComponent<FarmPlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Harvest()
    {
        farmPlot.InteractBare(player);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("on");
        if (col.tag == "Player")
        {
            harvestOn = true;
                player = col.GetComponent<Player>();
                col.GetComponent<playerMovement>().harvestOn();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("off");
        if (col.tag == "Player")
        {
            harvestOn = false;
            col.GetComponent<playerMovement>().harvestOff();
        }
    }
}
