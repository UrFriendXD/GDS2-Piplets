using TMPro;
using UnityEngine;

namespace Terminal
{
    public class ProcessingItemButton : TerminalAddRemoveButton
    {
        [HideInInspector]
        public CraftingRecipe craftingRecipe;

        [SerializeField] private TextMeshProUGUI amountRequiredText;

        private void Update()
        {
            // Adds amount
            if (_adding && _delay <= 0)
            {
                if (craftingRecipe.CanCraft(PlayerInventory, _amount + 1))
                {
                    UpdateAmount(_amount += 1);
                    _delay = delayReset;
                    pass.Post(gameObject);
                }
            }

            // Removes amount
            if (_removing && _delay <= 0)
            {
                if (_amount > 0)
                {
                    UpdateAmount(_amount -= 1);
                    _delay = delayReset;
                    fail.Post(gameObject);
                }
            }

            // Timer
            if (_delay > 0)
            {
                _delay -= Time.deltaTime;
            }
        }

        private new void UpdateAmount(int changeAmount)
        {
            _amount = changeAmount;
            amountText.text = "" + changeAmount * craftingRecipe.Results[0].Amount;
            amountRequiredText.text = "" + craftingRecipe.Materials[0].Amount * _amount;
        }

        public void OnCraftItemButtonClick()
        {
            craftingRecipe.Craft(PlayerInventory, _amount);
            UpdateAmount(0);
        }
    }
}
