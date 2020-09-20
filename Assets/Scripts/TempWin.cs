using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TempWin : MonoBehaviour
{
    public PlayerStats playerStats;
    [SerializeField] private int amount;
    public GameObject img;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerStats.money >= amount)
        {
            img.SetActive(true);
        }
    }
}
