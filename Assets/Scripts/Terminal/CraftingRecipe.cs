using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemAmount
{
	public Item Item;
	[Range(1, 999)]
	public int Amount;
}

[CreateAssetMenu(menuName = "Items/CraftingRecipe")]
public class CraftingRecipe : ScriptableObject
{
	public List<ItemAmount> Materials;
	public List<ItemAmount> Results;

	public bool CanCraft(IItemContainer itemContainer, int amount)
	{
		return HasMaterials(itemContainer, amount) && HasSpace(itemContainer);
	}

	private bool HasMaterials(IItemContainer itemContainer, int amount = 1)
	{
		foreach (ItemAmount itemAmount in Materials)
		{
			if (itemContainer.ItemCount(itemAmount.Item.ID) < itemAmount.Amount * amount)
			{
				Debug.LogWarning("You don't have the required materials.");
				return false;
			}
		}
		return true;
	}

	private bool HasSpace(IItemContainer itemContainer)
	{
		foreach (ItemAmount itemAmount in Results)
		{
			Debug.Log(itemContainer);
			if (!itemContainer.CanAddItem(itemAmount.Item, itemAmount.Amount))
			{
				Debug.LogWarning("Your inventory is full.");
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
				AddResults(itemContainer);
			}
		}
	}

	private void RemoveMaterials(IItemContainer itemContainer)
	{
		foreach (ItemAmount itemAmount in Materials)
		{
			for (int i = 0; i < itemAmount.Amount; i++)
			{
				Item oldItem = itemContainer.RemoveItem(itemAmount.Item.ID);
				oldItem.Destroy();
			}
		}
	}

	private void AddResults(IItemContainer itemContainer)
	{
		foreach (ItemAmount itemAmount in Results)
		{
			for (int i = 0; i < itemAmount.Amount; i++)
			{
				itemContainer.AddItem(itemAmount.Item.GetCopy());
			}
		}
	}
}
