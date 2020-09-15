using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Door : InteractableObject
{
    public GameObject greenhouse;
    public GameObject outsideGreenHouse;
    public GameObject piplet;

    public override void InteractBare(PlayerScript player)
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
