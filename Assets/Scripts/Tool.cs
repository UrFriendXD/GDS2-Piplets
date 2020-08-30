using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public bool hit;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void On()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public void Off()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        hit = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
