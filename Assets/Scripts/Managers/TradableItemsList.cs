using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/TradableItemList")]
public class TradableItemsList : ScriptableObject
{
    public List<TradableItem> TradableItems;
}
