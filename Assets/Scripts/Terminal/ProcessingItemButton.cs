using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProcessingItemButton : TerminalAddRemoveButton
{
    [HideInInspector]
    public CraftingRecipe _craftingRecipe;

    private void Update()
    {
        // Adds amount
        if (_adding && _delay <= 0)
        {
            if (_craftingRecipe.CanCraft(PlayerInventory, _amount + 1))
            {
                UpdateAmount(_amount += 1);
                _delay = delayReset;
            }
        }

        // Removes amount
        if (_removing && _delay <= 0)
        {
            if (_amount > 0)
            {
                UpdateAmount(_amount -= 1);
                _delay = delayReset;
            }
        }

        // Timer
        if (_delay > 0)
        {
            _delay -= Time.deltaTime;
        }
    }

    public void ResetAmount()
    {
        UpdateAmount(0);
    }
}
