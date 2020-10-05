using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetCratingRatios : MonoBehaviour
{
    [Header("Icons")] 
    [SerializeField] private Image rawGoodItemIcon;
    [SerializeField] private Image processingItemIcon;

    [Header("Text")] 
    [SerializeField] private TextMeshProUGUI amountNeededText;
    [SerializeField] private TextMeshProUGUI amountProducedText;

    [SerializeField] private CraftingRecipe _craftingRecipe;
    // Start is called before the first frame update
    void OnValidate()
    {
        rawGoodItemIcon.sprite = _craftingRecipe.Materials[0].Item.icon;
        processingItemIcon.sprite = _craftingRecipe.Results[0].Item.icon;

        amountNeededText.text = "" + _craftingRecipe.Materials[0].Amount;
        amountProducedText.text = "" + _craftingRecipe.Results[0].Amount;
    }
}
