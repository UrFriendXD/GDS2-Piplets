using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManagement : MonoBehaviour
{
    public int addSap, addAloe, addCotton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSeed(int value)
    {
        if(value == 1)
        {
            addSap = addSap + 1;
        }
        if (value == 2)
        {
            addAloe = addAloe + 1;
        }
        if (value == 3)
        {
            addCotton = addCotton + 1;
        }
    }
}
