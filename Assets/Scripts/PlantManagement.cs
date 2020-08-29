using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManagement : MonoBehaviour
{
    public int amountSap, amountAloe, amountCotton;
    public bool sap, aloe, cotton;
    // Start is called before the first frame update

    public void SwitchSeedType(int value)
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
