using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipletManager : IGameService
{
    public Action PipletBoughtEvent;

    private int amountOfPipletUnlocked;

    private int amountOfPipletNeededToWin;
    // Start is called before the first frame update
    public void Setup(int amountNeeded)
    {
        amountOfPipletNeededToWin = amountNeeded;
        PipletBoughtEvent += PipletBought;
    }

    public void PipletBought()
    {
        amountOfPipletUnlocked++;
    }
}
