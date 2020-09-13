using UnityEngine;

namespace Farming
{
    public class Tree : InteractableObject
    {
        public bool treeDied;
        public int treeHealth;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void InteractWithItem(Item item, Player player)
        {
            Debug.Log("hit");
            if (item.name == "Axe")
            {
                hit();
            }

        }

        public void hit()
        {
            Debug.Log("Hit");
            treeHealth = treeHealth - 1;
            DamageTree();
        }

        public void DamageTree()
        {
            wood Wood = gameObject.GetComponentInChildren<wood>();
            if (treeHealth == 2)
            {
                //changeTreeColour for now then changeTreeSprite
                Wood.woodDrop(2);
            }
            if (treeHealth == 1)
            {
                //changeTreeColour for now then changeTreeSprite
                Wood.woodDrop(2);
            }
            if (treeHealth == 0)
            {
                Wood.woodDrop(1);
                Death();
            }
        }

        public void Death()
        {
            treeDied = true;
            SpriteRenderer m = GetComponent<SpriteRenderer>();
            m.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            wood Wood = gameObject.GetComponentInChildren<wood>();
            Wood.woodOn();
        }
    }

}
