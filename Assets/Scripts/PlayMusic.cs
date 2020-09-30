using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AK.Wwise.Event Event;
    // Start is called before the first frame update
    void Start()
    {
        Event.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
