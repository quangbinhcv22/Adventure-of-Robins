using System;
using System.Collections.Generic;

namespace SandBox.Scripts
{
    [Serializable]
    public class CharacterStats
    {
        private Dictionary<CharacterStatType, CharacterStat> _stats = new Dictionary<CharacterStatType, CharacterStat>();

        public CharacterStat GetStat(CharacterStatType statType)
        {
            //if (_stats.ContainsKey(statType) == false) AddStat(statType, new CharacterStat());
            return _stats[statType];
        }

        public void AddStat(CharacterStatType statType, CharacterStat stat)
        {
            if (_stats.ContainsKey(statType)) return;
            _stats.Add(statType, stat);
        }
    }

    public enum CharacterStatType
    {
        Health = 1,
        Damage = 2,
    }
}