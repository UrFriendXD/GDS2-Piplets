using UnityEngine;

public class GiveItemTest : MonoBehaviour
{
    [SerializeField] private Item item;

    [SerializeField] private int amount = 1;

    [SerializeField] private Inventory inventory;
    
    [SerializeField] private KeyCode itemPickupKeyCode = KeyCode.E;
    
    private bool _isEmpty;
    private void OnValidate()
    {
        if (inventory == null)
            inventory = FindObjectOfType<Inventory>();
        
    }
    
    private void Update()
    {
        if (!_isEmpty && Input.GetKeyDown(itemPickupKeyCode))
        {
            Debug.Log("Item pressed");
            Item itemCopy = item.GetCopy();
            if (inventory.AddItem(itemCopy))
            {
                amount--;
                if (amount == 0)
                {
                    _isEmpty = true;
                }
                Debug.Log("Gave item");
            }
            else
            {
                itemCopy.Destroy();
            }
        }
    }
}
