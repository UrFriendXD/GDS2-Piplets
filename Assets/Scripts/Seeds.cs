using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeds : MonoBehaviour
{
    public int plantNum;
    public bool picked;
    // Start is called before the first frame update
    void Start()
    {
        picked = false;
        if(this.tag == "Sap" )
        {
            plantNum = 1;
        }
        if (this.tag == "Aloe")
        {
            plantNum = 2;
        }
        if (this.tag == "Cotton")
        {
            plantNum = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("on");
        if (col.tag == "Player" && picked == false)
        {
            picked = true;
            col.GetComponent<PlantManagement>().AddSeed(plantNum);
            seedPicked();
        }
    }

    public void seedPicked()
    {
        if (picked == true)
        {
            Destroy(this.gameObject);
        }
    }
}
