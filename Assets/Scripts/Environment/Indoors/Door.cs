﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableObject
{
    public GameObject greenhouse;
    public GameObject outsideGreenHouse;
    public GameObject piplet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void InteractBare(Player player)
    {
        base.InteractBare(player);
        greenhouse.SetActive(!greenhouse.activeSelf);
        outsideGreenHouse.SetActive(!outsideGreenHouse.activeSelf);
        if (greenhouse.activeSelf)
        {
            player.GetComponent<SpriteRenderer>().sortingOrder = 2;
            piplet.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        else
        {
            player.GetComponent<SpriteRenderer>().sortingOrder = 3;
            piplet.GetComponent<SpriteRenderer>().sortingOrder = 3;
        }
    }
}
