using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float waterpos;
    public bool waterOn;
    // Start is called before the first frame update
    void Start()
    {
        waterpos = transform.position.x;
        waterOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void water()
    {
        //waterScript
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("on");
        if (col.tag == "Player")
        {
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
