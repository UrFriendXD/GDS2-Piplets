using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood : MonoBehaviour
{
    public bool picked;
    public int WoodDrop;
    // Start is called before the first frame update
    void Start()
    {
        WoodDrop = 0;
        GetComponent<BoxCollider2D>().enabled = false;
        picked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void woodDrop(int drop)
    {
        WoodDrop = WoodDrop + drop; 
    }

    public void woodOn()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("on");
        if (col.tag == "Player" && picked == false)
        {
            picked = true;
            col.GetComponent<MaterialManagement>().AddMaterial(WoodDrop);
            woodPicked();
        }
    }

    public void woodPicked()
    {
        if (picked == true)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
