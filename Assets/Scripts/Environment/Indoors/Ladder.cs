using UnityEngine;

namespace Environment.Indoors
{
    public class Ladder : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("on");
            if(col.tag == "Player")
            {
                col.GetComponent<playerMovement>().LadderOn();
            }
        }

        void OnTriggerExit2D(Collider2D col)
        {
            Debug.Log("off");
            if (col.tag == "Player")
            {
                col.GetComponent<playerMovement>().LadderOff();
            }
        }
    }
}
