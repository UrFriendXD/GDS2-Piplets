﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.FinalDoorStopper = gameObject;
    }
}
