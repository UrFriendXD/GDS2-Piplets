using Player;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public bool picked;
    private PlayerScript _player;
    public PlantSeed plantSeed;
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

    public void WoodDrop(int drop)
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
            plantSeed.amountToGive = wooddrop;
            for (var i = 0; i < plantSeed.amountToGive; i++)
            {
                _player = other.GetComponent<PlayerScript>();
                _player.inventory.AddItem(plantSeed.rawGoodToGive);
            }
            plantSeed.amountToGive = 0;
            WoodPicked();
        }
    }

    public void WoodPicked()
    {
        if (picked == true)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
