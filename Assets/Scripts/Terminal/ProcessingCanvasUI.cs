using UnityEngine;

public class ProcessingCanvasUI : MonoBehaviour
{
    private CraftingRecipeUI[] craftingRecipeUis;

    private Inventory _inventory;

    // Start is called before the first frame update
    public void Initialise()
    {
        craftingRecipeUis = GetComponentsInChildren<CraftingRecipeUI>();
    }

    public void OpenProcessingMenu(Inventory inventory)
    {
        gameObject.SetActive(true);

        // Initialise crafting recipes only once (i.e. inventory is empty)
        if (!_inventory)
        {
            _inventory = inventory;
            foreach (var craftingRecipeUi in craftingRecipeUis)
            {
                craftingRecipeUi.inventory = _inventory;
            }
        }
    }

    // Simply closes the processing Menu
    public void CloseProcessingMenu()
    {
        gameObject.SetActive(false);
    }

    // Clears inventory in craftingRecipeUis
    public void CloseUI()
    {
        foreach (var craftingRecipeUi in craftingRecipeUis)
        {
            craftingRecipeUi.inventory = null;
        }

        _inventory = null;
        gameObject.SetActive(false);
    }
    
    // Crafts all currently selected crafts. Called by buttons
    public void CraftItems()
    {
        foreach (var craftingRecipeUi in craftingRecipeUis)
        {
            craftingRecipeUi.OnCraftButtonClick();
        }
    }

}
