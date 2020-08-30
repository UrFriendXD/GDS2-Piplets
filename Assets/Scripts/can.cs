using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class can : Tool
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("on");
        if (other.CompareTag("Plant"))
        {
            if (hit == false)
            {
                other.GetComponent<Water>().water();
                hit = true;
            }
        }
    }
}
