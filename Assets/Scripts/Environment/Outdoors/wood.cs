using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood : MonoBehaviour
{
    public bool picked;
    private Player player;
    public PlantSeed _plantSeed;
    public int wooddrop;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        picked = false;
        //wooddrop = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void woodDrop(int drop)
    {
        wooddrop = wooddrop + drop; 
    }

    public void woodOn()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            picked = true;
            _plantSeed.amountToGive = wooddrop;
            for (var i = 0; i < _plantSeed.amountToGive; i++)
            {
                player = other.GetComponent<Player>();
                player.inventory.AddItem(_plantSeed.rawGoodToGive);
            }
            _plantSeed.amountToGive = 0;
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
