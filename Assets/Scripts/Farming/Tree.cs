using Player;
using System.Collections;
using UnityEngine;

namespace Farming
{
    public class Tree : InteractableObject
    {
        public bool treeDied;
        public int treeHealth;
        public GameObject treeparticle; // this should be a particle effect can have many to change the particle effect
        private GameObject clone; // to clone the particle effect
        public override void InteractWithItem(Item item, PlayerScript player)
        {
            Debug.Log("hit");
            if (item.name == "Axe")
            {
                hit();
                clone = Instantiate(treeparticle, new Vector3(0f, 0f, 0f), Quaternion.identity); // clones the particle effect
                this.GetComponent<OutsideParticleEffects>().ParticleOn(clone); // this line triggers the particle effect
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
