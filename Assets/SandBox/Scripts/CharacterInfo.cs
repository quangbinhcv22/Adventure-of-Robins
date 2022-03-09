using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterInfo : MonoBehaviour
    {
        [SerializeField] private string id;
        [SerializeField] private GameEvent.EventName.CharacterTeam team;
        [SerializeField] private CharacterStat health;
        [SerializeField] private CharacterStat damage;

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

        public string ID => id;
        
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
