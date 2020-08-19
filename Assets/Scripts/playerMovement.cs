using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public Input controls;
    void awake() 
    {
        controls.player.movement.performed += ctx => move();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void move()
    {
        Debug.Log("move");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
