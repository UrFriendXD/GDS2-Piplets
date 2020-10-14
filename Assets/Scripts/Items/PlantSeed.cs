using System;
using Farming;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant Seed", menuName = "Items/PlantSeed")]
public class PlantSeed : Item
{
    [Serializable]
    public class SpriteArray
    {
        public Sprite[] sprites;
    }
    
    public PlantType plantType;
    public int daysToStage1;
    public int daysToStage2;
    public int daysToStage3;
    public int daysToHarvest;
    public SpriteArray[] spritesList;
    public float amountToGive;
    public Item rawGoodToGive;
}
