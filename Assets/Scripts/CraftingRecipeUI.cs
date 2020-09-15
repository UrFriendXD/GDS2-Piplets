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

	private void OnValidate()
	{
		processingItemButton = GetComponentInChildren<ProcessingItemButton>(includeInactive: true);
	}

	private void Start()
	{
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
	
}
