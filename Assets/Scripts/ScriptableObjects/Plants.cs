using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class Plants : ScriptableObject
{
    public PlantType plantType;
    public int daysToStage1;
    public int daysToHarvest;
    public Sprite[] plantSprites;
    public float amountToGive;
}
