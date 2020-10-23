using Player.Stats;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Player/PlayerStats")]
    public class PlayerStats : ScriptableObject
    {
        [Header("Money")]
        public int money;

        [Header("Stats")] 
        public CharacterStat movespeed;
        public CharacterStat harvestingDoublerModifier;
        public CharacterStat harvestingSeedModifier;

    }
}
