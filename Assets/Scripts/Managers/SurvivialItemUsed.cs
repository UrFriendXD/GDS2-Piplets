using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/SurvivalItemsNeeded")]
public class SurvivialItemUsed : ScriptableObject
{
    public List<ItemAmount> materials;

    public bool CanCraft(IItemContainer itemContainer, int amount = 1)
    {
        return HasMaterials(itemContainer, amount);
    }
    
    private bool HasMaterials(IItemContainer itemContainer, int amount = 1)
    {
        foreach (ItemAmount itemAmount in materials)
        {
            if (itemContainer.ItemCount(itemAmount.Item.ID) < itemAmount.Amount * amount)
            {
                Debug.LogWarning("You don't have the required materials. You go to sleep for the season");
                return false;
            }
        }
        return true;
    }

    public void Craft(IItemContainer itemContainer, int amount = 1)
    {
        if (CanCraft(itemContainer, amount))
        {
            for (int i = 0; i < amount; i++)
            {
                RemoveMaterials(itemContainer);
            }
        }
    }
    
    private void RemoveMaterials(IItemContainer itemContainer)
    {
        foreach (ItemAmount itemAmount in materials)
        {
            for (int i = 0; i < itemAmount.Amount; i++)
            {
                Item oldItem = itemContainer.RemoveItem(itemAmount.Item.ID);
                oldItem.Destroy();
            }
        }
    }
}