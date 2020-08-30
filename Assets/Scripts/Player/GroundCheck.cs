using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
 
    // Start is called before the first frame update
    void Start()
    {
        playerMovement player = gameObject.GetComponentInParent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("on");
        if (col.tag == "Ground")
        {
            playerMovement player = gameObject.GetComponentInParent<playerMovement>();
            player.GroundOn();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        //Debug.Log("off");
        if (col.tag == "Ground")
        {
            playerMovement player = gameObject.GetComponentInParent<playerMovement>();
            player.GroundOff();
        }
    }
}
