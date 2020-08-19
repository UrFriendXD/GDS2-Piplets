using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Input;

public class playerMovement : MonoBehaviour
{
    public input controls;
    void awake()
    {
        controls.player.movement.preformed += ctx => move();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void move()
    {
        Debug.log("move");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
