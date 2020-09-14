using System;
using System.Collections.Generic;
using UnityEngine;

public class CraftingRecipeUI : MonoBehaviour
{
	[Header("References")]
	//[SerializeField] RectTransform arrowParent;
	
	[HideInInspector]
	public ProcessingItemButton processingItemButton;

	[Header("Public Variables")]
	public Inventory inventory;

	[SerializeField] private CraftingRecipe craftingRecipe;
	public CraftingRecipe CraftingRecipe {
		get { return craftingRecipe; }
		//set { SetCraftingRecipe(value); }
	}

	//public event Action<BaseItemSlot> OnPointerEnterEvent;
	//public event Action<BaseItemSlot> OnPointerExitEvent;

	private void OnValidate()
	{
		processingItemButton = GetComponentInChildren<ProcessingItemButton>(includeInactive: true);
	}

	private void Start()
	{
		/*foreach (BaseItemSlot itemSlot in itemSlots)
		{
			itemSlot.OnPointerEnterEvent += slot => OnPointerEnterEvent(slot);
			itemSlot.OnPointerExitEvent += slot => OnPointerExitEvent(slot);
		}*/

		// Initialise values of button
		processingItemButton.PlayerInventory = inventory;
		processingItemButton._craftingRecipe = craftingRecipe;
	}

	public void OnCraftButtonClick()
	{
		if (craftingRecipe != null && inventory != null)
		{
			craftingRecipe.Craft(inventory);
			processingItemButton.ResetAmount();
		}
	}

	/*private void SetCraftingRecipe(CraftingRecipe newCraftingRecipe)
	{
		craftingRecipe = newCraftingRecipe;

		if (craftingRecipe != null)
		{
			int slotIndex = 0;
			slotIndex = SetSlots(craftingRecipe.Materials, slotIndex);
			arrowParent.SetSiblingIndex(slotIndex);
			slotIndex = SetSlots(craftingRecipe.Results, slotIndex);

			for (int i = slotIndex; i < itemSlots.Length; i++)
			{
				itemSlots[i].transform.parent.gameObject.SetActive(false);
			}

			gameObject.SetActive(true);
		}
		else
		{
			gameObject.SetActive(false);
		}
	}

	private int SetSlots(IList<ItemAmount> itemAmountList, int slotIndex)
	{
		for (int i = 0; i < itemAmountList.Count; i++, slotIndex++)
		{
			ItemAmount itemAmount = itemAmountList[i];
			BaseItemSlot itemSlot = itemSlots[slotIndex];

			itemSlot.Item = itemAmount.Item;
			itemSlot.Amount = itemAmount.Amount;
			itemSlot.transform.parent.gameObject.SetActive(true);
		}
		return slotIndex;
	}*/
}
