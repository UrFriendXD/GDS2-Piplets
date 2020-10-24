using Terminal;
using UnityEngine;
using UnityEngine.UI;

public class CraftingRecipeUI : MonoBehaviour
{
	[Header("References")]
	//[SerializeField] RectTransform arrowParent;
	
	[HideInInspector]
	public ProcessingItemButton processingItemButton;

	[Header("Icons")] 
	[SerializeField] private Image rawGoodItemIcon;
	[SerializeField] private Image processingItemIcon;
	

	[Header("Public Variables")]
	public Inventory inventory;

	[SerializeField] private CraftingRecipe craftingRecipe;

	private void OnValidate()
	{
		processingItemButton = GetComponentInChildren<ProcessingItemButton>(true);

		rawGoodItemIcon.sprite = craftingRecipe.Materials[0].Item.icon;
		processingItemIcon.sprite = craftingRecipe.Results[0].Item.icon;
	}

	private void Start()
	{
		// Initialise values of button
		processingItemButton.PlayerInventory = inventory;
		processingItemButton.craftingRecipe = craftingRecipe;
	}

	public void OnCraftButtonClick()
	{
		if (craftingRecipe != null && inventory != null)
		{
			processingItemButton.OnCraftItemButtonClick();
		}
	}
	
}
