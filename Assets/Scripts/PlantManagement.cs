using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManagement : MonoBehaviour
{
    public int amountSap, amountAloe, amountCotton;
    public bool sap, aloe, cotton;
    // Start is called before the first frame update
    void Start()
    {
        sap = true;
        aloe = false;
        cotton = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkSeeds();
    }

    public void checkSeeds()
    {
        if(sap == true)
        {
            this.GetComponent<playerMovement>().updateSeed(amountSap);
        }
        if (aloe == true)
        {
            this.GetComponent<playerMovement>().updateSeed(amountAloe);
        }
        if(cotton == true)
        {
            this.GetComponent<playerMovement>().updateSeed(amountCotton);
        }    
    }

    public void AddSeed(int value)
    {
        if(value == 1)
        {
            amountSap = amountSap + 1;
        }
        if (value == 2)
        {
            amountAloe = amountAloe + 1;
        }
        if (value == 3)
        {
            amountCotton = amountCotton + 1;
        }
    }

    public void switchSeedType(int value)
    {
        if(value == 1)
        {
            sap = true;
            aloe = false;
            cotton = false;
        }
        if(value == 2)
        {
            sap = false;
            aloe = true;
            cotton = false;
        }
        if(value == 3)
        {
            sap = false;
            aloe = false;
            cotton = true;
        }
    }
}
