using System;
using SandBox.Scripts;

namespace GamePlay.Character
{
    [Serializable]
    public class CharacterInfo
    {
        public string id;
        public CharacterTeam team;
        public HeroID heroID;
        public Side side;
        public CharacterStat health;
        public CharacterStat damage;

        public CharacterStat Health
        {
            get => health;
        }

        public CharacterStat Damage => damage;

        public CharacterTeam Team => team;


        //public CharacterStats stats;
        // [SerializeField] private CharacterStat strength;
        // [SerializeField] private CharacterStat vitality;
        // [SerializeField] private CharacterStat dexterity;
        // [SerializeField] private CharacterStat intelligence;
        // [SerializeField] private CharacterStat damage;
        
        private void Start()
        {
            

            // stats.AddStat(CharacterStatType.Health,new CharacterStat(1000));
            // stats.GetStat(CharacterStatType.Health).ResetCurrentByValue();
            //
            // stats.AddStat(CharacterStatType.Damage,new CharacterStat(100));
        }
    }
}
