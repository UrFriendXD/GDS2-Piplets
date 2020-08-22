using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public float treepos;
    public bool treeOn, treeDied;
    public int treeHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        treepos = transform.position.x;
        treeOn = false;
        treeDied = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hit()
    {
        if(treeOn == true)
        {
            Debug.Log("Hit");
            treeHealth = treeHealth - 1;
            DamageTree();
        }
    }

    public void DamageTree()
    {
        wood Wood = gameObject.GetComponentInChildren<wood>();
        if (treeHealth == 2)
        {
            //changeTreeColour for now then changeTreeSprite
            Wood.woodDrop(2);
        }
        if(treeHealth == 1)
        {
            //changeTreeColour for now then changeTreeSprite
            Wood.woodDrop(2);
        }
        if(treeHealth == 0)
        {
            Wood.woodDrop(1);
            Death();
        }
    }

    public void Death()
    {
        treeDied = true;
        MeshRenderer m = GetComponent<MeshRenderer>();
        m.enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        wood Wood = gameObject.GetComponentInChildren<wood>();
        Wood.woodOn();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("on");
        if (col.tag == "Player")
        {
            treeOn = true;
            col.GetComponent<playerMovement>().chopOn(treepos);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("off");
        if (col.tag == "Player")
        {
            treeOn = false;
            col.GetComponent<playerMovement>().chopOff();
        }
    }
}
