
using System;

namespace SandBox.Scripts
{
    [Serializable]
    public class CharacterInfo
    {
        public string id;
        public GameEvent.EventName.CharacterTeam team;
        public CharacterStat health;
        public CharacterStat damage;

        public CharacterStat Health
        {
            get => health;
        }

        public CharacterStat Damage => damage;

        public GameEvent.EventName.CharacterTeam Team => team;


        //public CharacterStats stats;
        // [SerializeField] private CharacterStat strength;
        // [SerializeField] private CharacterStat vitality;
        // [SerializeField] private CharacterStat dexterity;
        // [SerializeField] private CharacterStat intelligence;
        // [SerializeField] private CharacterStat damage;
        
        
        private void Start()
        {
            health.ResetCurrentByValue();
            damage.ResetCurrentByValue();

            // stats.AddStat(CharacterStatType.Health,new CharacterStat(1000));
            // stats.GetStat(CharacterStatType.Health).ResetCurrentByValue();
            //
            // stats.AddStat(CharacterStatType.Damage,new CharacterStat(100));
        }
    }
}
