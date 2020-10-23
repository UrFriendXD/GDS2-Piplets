using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using Object = UnityEngine.Object;

public class PipletManager : IGameService
{
    public List<Piplet>_piplets = new List<Piplet>();
    //public List<Piplet> ActivePiplets = new List<Piplet>();
    public Action PipletBoughtEvent;

    private int amountOfPipletUnlocked;
    private int amountOfPipletNeededToWin;
    // Start is called before the first frame update
    public void Setup(int amountNeeded)
    {
        amountOfPipletUnlocked = 0;
        amountOfPipletNeededToWin = amountNeeded;
        PipletBoughtEvent += PipletBought;
        if (_piplets.Count > 0)
        {
            _piplets.Clear();
        }

        var _pipletsList = Object.FindObjectsOfType<Piplet>(true);
        foreach (var piplet in _pipletsList)
        {
            _piplets.Add(piplet);
            piplet.Setup();
        }

        //     _piplets.Sort(delegate(Piplet piplet, Piplet piplet1)
        //     {
        //         if (piplet.pipletStats.pipletType == null && piplet1.pipletStats.pipletType == null) return 0;
        //         if (piplet.pipletStats.pipletType == null) return -1;
        //         if (piplet1.pipletStats.pipletType == null) return 1;
        //         return piplet.pipletStats.pipletType.CompareTo(piplet1.pipletStats.pipletType);
        //     });
        //     
        //     Debug.Log(_piplets);
    }

    public void PipletBought()
    {
        amountOfPipletUnlocked++;
        if (amountOfPipletUnlocked == amountOfPipletNeededToWin)
        {
            GameManager.instance.OpenEnding();
        }
    }
}
