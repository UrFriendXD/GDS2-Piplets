using UnityEngine;
using Kryz.CharacterStats;
using Player;

public enum PipletType
{
    Piplet1,
    Piplet2,
    Piplet3,
    Piplet4,
    Piplet5,
    Piplet6,
}

[CreateAssetMenu(menuName = "Piplet/PipletStats")]
public class PipletStats : Item
{
    public float movespeedPercentBonus;
    public int harvestingDoublerBonus;
    public int harvestingSeedBonus;
    [Space]
    public PipletType pipletType;

    public int level;

    [Space] public bool isUnlocked;

    public override Item GetCopy()
    {
        return Instantiate(this);
    }

    public override void Destroy()
    {
        Destroy(this);
    }

    public void Equip(PlayerStats player)
    {
        // Adds bonus is not zero. Also adds percent or flat
        if (movespeedPercentBonus != 0)
            player.movespeed.AddModifier(new StatModifier(movespeedPercentBonus, StatModType.PercentAdd, this));
        if (harvestingDoublerBonus != 0)
            player.harvestingDoublerModifier.AddModifier(new StatModifier(harvestingDoublerBonus, StatModType.Flat, this));
        if (harvestingSeedBonus != 0)
            player.harvestingSeedModifier.AddModifier(new StatModifier(harvestingSeedBonus, StatModType.Flat, this));
        
        // if (StrengthPercentBonus != 0)
        // 	c.Strength.AddModifier(new StatModifier(StrengthPercentBonus, StatModType.PercentMult, this));
        // if (AgilityPercentBonus != 0)
        // 	c.Agility.AddModifier(new StatModifier(AgilityPercentBonus, StatModType.PercentMult, this));
        // if (IntelligencePercentBonus != 0)
        // 	c.Intelligence.AddModifier(new StatModifier(IntelligencePercentBonus, StatModType.PercentMult, this));
        // if (VitalityPercentBonus != 0)
        // 	c.Vitality.AddModifier(new StatModifier(VitalityPercentBonus, StatModType.PercentMult, this));
    }

    public void Unequip(PlayerStats player)
    {
        player.movespeed.RemoveAllModifiersFromSource(this);
        player.harvestingDoublerModifier.RemoveAllModifiersFromSource(this);
        player.harvestingSeedModifier.RemoveAllModifiersFromSource(this);
    }

    // Everything under here idk what to use it for or what it does tbh
    public override string GetItemType()
    {
        return pipletType.ToString();
    }

    public override string GetDescription()
    {
        sb.Length = 0;
        AddStat(movespeedPercentBonus, "Movespeed Bonus");
        AddStat(harvestingDoublerBonus, "Harvesting Doubler Modifier");
        AddStat(harvestingSeedBonus, "Harvesting Seed Modifier");
        return sb.ToString();
    }

    private void AddStat(float value, string statName, bool isPercent = false)
    {
        if (value == 0) return;
        
        if (sb.Length > 0)
            sb.AppendLine();

        if (value > 0)
            sb.Append("+");

        if (isPercent) {
            sb.Append(value * 100);
            sb.Append("% ");
        } else {
            sb.Append(value);
            sb.Append(" ");
        }
        sb.Append(statName);
    }
}