using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/TradableItem")]
public class TradableItem : Item
{
    public int buyingPrice;
    public int sellingPrice;
}
