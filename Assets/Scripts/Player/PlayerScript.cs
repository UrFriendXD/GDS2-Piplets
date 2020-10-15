using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerScript : MonoBehaviour
    {
        [Header("Public")]
        public PlayerStats playerStats;
        public Item itemHeld;
        public Inventory inventory;
        public PlayerAudio playerAudio;
        public playerMovement playerMovement;
        public PlayerAnimationController playerAnimationController;
        public int PlayerID;

        [Header("Serialize Field")]
        [SerializeField] private ItemSaveManager itemSaveManager;
        [SerializeField] Image draggableItem;
        
        private BaseItemSlot dragItemSlot;

        private void Awake()
        {
            PlayerID = ServiceLocator.Current.Get<PlayersManager>().AddPlayer(this);
            
            // Begin Drag
            inventory.OnBeginDragEvent += BeginDrag;
            
            // End Drag
            inventory.OnEndDragEvent += EndDrag;
            
            // Drag
            inventory.OnDragEvent += Drag;
            
            // Drop
            inventory.OnDropEvent += Drop;
        }
        
        private void Start()
        {
            if (itemSaveManager != null)
            {
                itemSaveManager.LoadInventory(this);
            }
        }

        private void OnDestroy()
        {
            if (itemSaveManager != null)
            {
                itemSaveManager.SaveInventory(this);
            }
        }

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
        
        private void BeginDrag(BaseItemSlot itemSlot)
        {
            if (itemSlot.Item != null)
            {
                dragItemSlot = itemSlot;
                draggableItem.sprite = itemSlot.Item.icon;
                draggableItem.transform.position = Input.mousePosition;
                draggableItem.gameObject.SetActive(true);
            }
        }
        
        private void Drag(BaseItemSlot itemSlot)
        {
            draggableItem.transform.position = Input.mousePosition;
        }

        private void EndDrag(BaseItemSlot itemSlot)
        {
            dragItemSlot = null;
            draggableItem.gameObject.SetActive(false);
        }

        private void Drop(BaseItemSlot dropItemSlot)
        {
            if (dragItemSlot == null) return;

            if (dropItemSlot.CanAddStack(dragItemSlot.Item))
            {
                AddStacks(dropItemSlot);
            }
            else if (dropItemSlot.CanReceiveItem(dragItemSlot.Item) && dragItemSlot.CanReceiveItem(dropItemSlot.Item))
            {
                SwapItems(dropItemSlot);
            }
        }
        
        private void AddStacks(BaseItemSlot dropItemSlot)
        {
            int numAddableStacks = dropItemSlot.Item.maximumStack - dropItemSlot.Amount;
            int stacksToAdd = Mathf.Min(numAddableStacks, dragItemSlot.Amount);

            dropItemSlot.Amount += stacksToAdd;
            dragItemSlot.Amount -= stacksToAdd;
        }
        
        private void SwapItems(BaseItemSlot dropItemSlot)
        {
            Item draggedItem = dragItemSlot.Item;
            int draggedItemAmount = dragItemSlot.Amount;

            dragItemSlot.Item = dropItemSlot.Item;
            dragItemSlot.Amount = dropItemSlot.Amount;

            dropItemSlot.Item = draggedItem;
            dropItemSlot.Amount = draggedItemAmount;
        }
    }
}
