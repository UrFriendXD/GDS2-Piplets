using UnityEngine;

namespace Player
{
    public class PlayerScript : MonoBehaviour
    {
        [SerializeField] private ItemSaveManager itemSaveManager;
        public PlayerStats playerStats;
        public Item itemHeld;
        public Inventory inventory;
        public PlayerAudio PlayerAudio;

        // Selects players item from inventory based on parameter
        public void SelectItem(string itemSelectName)
        {
            itemHeld = null;
            Debug.Log(itemSelectName);
            foreach (var item in inventory.ItemSlots)
            {
                if (!item.Item) continue;
                if (itemSelectName != item.Item.itemName) continue;
                itemHeld = item.Item;
                return;
            }
        }
    }
}
