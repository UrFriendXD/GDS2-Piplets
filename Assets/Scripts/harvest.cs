using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harvest : MonoBehaviour
{
    public bool harvestOn, harvestReady;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Harvest()
    {
        //waterScript
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("on");
        if (col.tag == "Player")
        {
            if (harvestReady == true)
            {
                harvestOn = true;
                col.GetComponent<playerMovement>().harvestOn();
            }
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
