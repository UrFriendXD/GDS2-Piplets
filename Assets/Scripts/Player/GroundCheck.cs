using UnityEngine;

namespace Player
{
    public class GroundCheck : MonoBehaviour
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
            if (col.tag == "Ground")
            {
                playerMovement player = gameObject.GetComponentInParent<playerMovement>();
                player.GroundOn();
            }
            if(col.tag == "Ground2")
            {
                playerMovement player = gameObject.GetComponentInParent<playerMovement>();
                player.GroundOn2();
            }
        }

        void OnTriggerExit2D(Collider2D col)
        {
            //Debug.Log("off");
            if (col.tag == "Ground")
            {
                playerMovement player = gameObject.GetComponentInParent<playerMovement>();
                player.GroundOff();
            }
            if (col.tag == "Ground2")
            {
                playerMovement player = gameObject.GetComponentInParent<playerMovement>();
                player.GroundOff2();
            }
        }
    }
}
