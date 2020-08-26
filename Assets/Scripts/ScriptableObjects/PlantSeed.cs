using System.Collections;
using System.Collections.Generic;
using Farming;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant Seed", menuName = "Items/Plant")]
public class PlantSeed : Item
{
    public PlantType plantType;
    public int daysToStage1;
    public int daysToHarvest;
    public Sprite[] plantSprites;
    public float amountToGive;
    public Item rawGoodToGive;
}
