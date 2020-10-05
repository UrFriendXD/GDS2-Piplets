using UnityEngine;

public class WallCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        playerMovement player = gameObject.GetComponentInParent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("on");
        if (col.tag == "Wall")
        {
            playerMovement player = gameObject.GetComponentInParent<playerMovement>();
            player.WallOn();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        //Debug.Log("off");
        if (col.tag == "Wall")
        {
            playerMovement player = gameObject.GetComponentInParent<playerMovement>();
            player.WallOff();
        }
    }
}
