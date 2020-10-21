using UnityEngine;

namespace Player
{
    public class GroundCheck : MonoBehaviour
    {
 
        // Start is called before the first frame update
        void Start()
        {
            PlayerMovement player = gameObject.GetComponentInParent<PlayerMovement>();
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
                PlayerMovement player = gameObject.GetComponentInParent<PlayerMovement>();
                player.GroundOn();
            }
            if(col.tag == "Ground2")
            {
                PlayerMovement player = gameObject.GetComponentInParent<PlayerMovement>();
                player.GroundOn2();
            }
            if (col.tag == "Ground3")
            {
                PlayerMovement player = gameObject.GetComponentInParent<PlayerMovement>();
                player.GroundOn3();
            }
        }

        void OnTriggerExit2D(Collider2D col)
        {
            //Debug.Log("off");
            if (col.tag == "Ground")
            {
                PlayerMovement player = gameObject.GetComponentInParent<PlayerMovement>();
                player.GroundOff();
            }
            if (col.tag == "Ground2")
            {
                PlayerMovement player = gameObject.GetComponentInParent<PlayerMovement>();
                player.GroundOff2();
            }
            if (col.tag == "Ground3")
            {
                PlayerMovement player = gameObject.GetComponentInParent<PlayerMovement>();
                player.GroundOff3();
            }
        }
    }
}
