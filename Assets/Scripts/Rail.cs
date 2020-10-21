using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{
    public GameObject player;
    public GameObject rails;    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(player.GetComponent<PlayerMovement>().Stairs == true && player.GetComponent<PlayerMovement>().GroundCheck2 == false && player.GetComponent<PlayerMovement>().GroundCheck3 == false)
        {
            rails.SetActive(true);
        }
        else   
        {
            rails.SetActive(false);
        }
            

    }
}
