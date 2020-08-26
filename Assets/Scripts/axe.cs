using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axe : MonoBehaviour
{
    public bool hit;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void axeOn()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public void axeOff()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        hit = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("on");
        if (col.tag == "Tree")
        {
            if (hit == false)
            {
                col.GetComponent<Tree>().hit();
                hit = true;
            }
        }
    }

}
