using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shovel : MonoBehaviour
{
    public bool hit;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        hit = false;
    }

    public void shovelOn()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public void shovelOff()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("on");
        if (col.tag == "Plant")
        {
            if (hit == false)
            {
                col.GetComponent<Plant>().plant();
                hit = true;
            }
        }
    }
}
