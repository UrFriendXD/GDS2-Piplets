using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public bool plantOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void plant()
    {
        //plantScript
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("on");
        if (col.tag == "Player")
        {
            plantOn = true;
            col.GetComponent<playerMovement>().plantOn();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("off");
        if (col.tag == "Player")
        {
            plantOn = false;
            col.GetComponent<playerMovement>().plantOff();
        }
    }
}
